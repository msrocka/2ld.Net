using System;

namespace openLCA.Schema.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // create or open a new data package
            var pack = new Package("C:/Users/Besitzer/Desktop/example-jsonld.zip");

            // create a top- and sub-category for the steel flow
            var topCategory = new Category();
            topCategory.ID = "e6a77d20-c8d4-4c02-b659-feedcdf279de";
            topCategory.Name = "Materials";
            topCategory.ModelType = ModelType.FLOW;
            pack.Put(topCategory);

            var subCategory = new Category();
            subCategory.ID = "01a51458-40e2-486c-a37c-92a15c189366";
            subCategory.Name = "Metals";
            subCategory.ModelType = ModelType.FLOW;
            subCategory.Category = Ref.Of(topCategory);
            pack.Put(subCategory);

            // create the steel flow and link it to mass
            var steel = new Flow();
            steel.ID = "fafb2e5d-db4e-4117-9e01-bc5097fc6735";
            steel.Name = "Steel";
            steel.Category = Ref.Of(subCategory);
            steel.FlowType = FlowType.PRODUCT_FLOW;
            var massRef = new FlowPropertyFactor();
            massRef.ConversionFactor = 1.0;
            massRef.IsReferenceFlowProperty = true;
            massRef.FlowProperty = new Ref("FlowProperty", 
                "93a60a56-a3c8-11da-a746-0800200b9a66", "Mass");
            steel.FlowProperties.Add(massRef);
            pack.Put(steel);



            /*
            var cat1 = new Category();
            cat1.ID = "abc";
            var cat2 = new Category();
            cat2.ID = "bca";
            
            if (!pack.Contains(cat1.GetType(), cat1.ID))
                pack.Put(cat1);
            if (!pack.Contains(cat2.GetType(), cat2.ID))
                pack.Put(cat2);
            pack.Close();
            pack = new Package("C:/Users/Besitzer/Desktop/abc.zip");
            pack.Each<Category>(cat =>
            {
                Console.WriteLine(cat.ToJson());
            });
            pack.Close();
            Console.WriteLine("Works!");
            */

            // close the Zip package
            pack.Close();

            Console.ReadKey();
        }
    }
}
