using System.IO;
using System.IO.Compression;
using System.Text;

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

        private string getFolder(Entity e)
        {
            if (e.Type == null)
                return "other";
            switch (e.Type)
            {
                case "Category":
                    return "categories";
                default:
                    return "otehr";
            }
        }
    }
}

