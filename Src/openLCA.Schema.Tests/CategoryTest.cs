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
        public void TestCategoryType()
        {
            var cat = new Category();
            Assert.AreSame(ModelType.CATEGORY, ModelType.Of(cat));
        }

    }
}
