﻿using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;

namespace openLCA.Schema
{
    public class Package
    {

        private ZipArchive zip;

        public Package(string path)
        {
            zip = ZipFile.Open(path, ZipArchiveMode.Update, Encoding.UTF8);
        }

        public void Close()
        {
            zip.Dispose();
        }

        public void Put(Entity e)
        {
            if (e == null || e.ID == null)
                return;
            var file = getFolder(e) + "/" + e.ID + ".json";
            var entry = zip.CreateEntry(file);
            using (var writer = new StreamWriter(entry.Open(), new UTF8Encoding(false)))
            {
                writer.Write(e.ToJson());
            }
        }

        public T Get<T>(string id) 
        {
            var type = typeof(T);
            var path = getFolder(type) + "/" + id + ".json";
            var entry = zip.GetEntry(path);
            return entry == null ? default(T) : read<T>(type, entry);                 
        }

        public void Each<T>(Action<T> fn)
        {
            var type = typeof(T);
            var folder = getFolder(type);
            foreach (var entry in zip.Entries)
            {
                if (!entry.FullName.StartsWith(folder))
                    continue;
                var obj = read<T>(type, entry);
                fn(obj);
            }
        }

        private T read<T>(Type t, ZipArchiveEntry e)
        {
            using (var reader = new StreamReader(e.Open(), new UTF8Encoding(false)))
            {
                var json = reader.ReadToEnd();
                return (T)JsonConvert.DeserializeObject(json, t);
            }
        }

        private string getFolder(Entity e)
        {
            if (e.Type == null)
                return "others";
            switch (e.Type)
            {
                case "Category":
                    return "categories";
                default:
                    return "others";
            }
        }

        private string getFolder(Type type)
        {
            if (type == null)
                return null;
            if (type == typeof(Category))
                return "categories";

            return "others";
        }        
    }
}

