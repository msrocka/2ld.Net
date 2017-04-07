using System;
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
            if (entry == null)
                return default(T);
            using (var reader = new StreamReader(entry.Open(), new UTF8Encoding(false)))
            {
                var json = reader.ReadToEnd();
                return (T)JsonConvert.DeserializeObject(json, type);
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

