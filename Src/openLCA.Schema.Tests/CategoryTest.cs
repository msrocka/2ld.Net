using NUnit.Framework;
using System;

namespace openLCA.Schema.Tests
{
    [TestFixture]
    public class CategoryTest
    {

        [Test]
        public void TestIO()
        {
            var cat = new Category();
            cat.ID = "abc2";
            cat.Name = "Brösel";
            var json = cat.ToJson();
            Console.WriteLine(json);
            var pack = new Package("C:/Users/Besitzer/Desktop/my.zip");
            pack.Put(cat);
            var clone = pack.Get<Category>(cat.ID);
            pack.Close();
            Assert.AreEqual("Brösel", clone.Name);
            Console.WriteLine("geht? " + clone.ID);
        }

        [Test]
        public void EachCategory()
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
        }

    }
}
