using System;

namespace openLCA.Schema.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var cat1 = new Category();
            cat1.ID = "abc";
            var cat2 = new Category();
            cat2.ID = "bca";
            var pack = new Package("C:/Users/Besitzer/Desktop/abc.zip");
            pack.Put(cat1);
            pack.Put(cat2);
            pack.Close();
            pack = new Package("C:/Users/Besitzer/Desktop/abc.zip");
            pack.Each<Category>(cat =>
            {
                Console.WriteLine(cat.ID);
            });
            pack.Close();
            Console.WriteLine("Works!");
            Console.ReadKey();
        }
    }
}
