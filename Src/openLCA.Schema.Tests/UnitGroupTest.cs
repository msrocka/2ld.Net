using System;
using NUnit.Framework;

namespace openLCA.Schema.Tests
{
    [TestFixture]
    public class UnitGroupTest
    {

        [Test]
        public void TestUnitGroup()
        {
            var kg = new Unit();
            kg.ID = "kg";
            kg.Name = "kg";
            kg.IsReferenceUnit = true;
            kg.ConversionFactor = 1.0;

            var group = new UnitGroup();
            group.ID = "Units_of_mass";
            group.Name = "Units of mass";
            group.Units.Add(kg);

            Console.WriteLine(group.ToJson());
        }
    }
}
