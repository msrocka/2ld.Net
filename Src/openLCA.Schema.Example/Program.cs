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

            // create an output of 1kg steel
            var steelOut = new Exchange();
            steelOut.IsInput = false;
            steelOut.Flow = Ref.Of(steel);
            steelOut.FlowProperty = massRef.FlowProperty;
            steelOut.Unit = new Ref("Unit", 
                "20aadc24-a391-41cf-b340-3e4529f44bde", "kg");
            steelOut.IsQuantitativeReference = true;
            steelOut.Amount = 1.0;

            // create the process
            var steelProduction = new Process();
            steelProduction.ID = "4d994382-bfab-4d5b-8d56-5135bdc039a2";
            steelProduction.Name = "Steel production";
            steelProduction.ProcessType = ProcessType.UNIT_PROCESS;
            steelProduction.Exchanges.Add(steelOut);
            pack.Put(steelProduction);


            /*
            TODO: show reading: 
            pack.Each<Category>(cat =>
            {
                Console.WriteLine(cat.ToJson());
            });
            */

            // close the Zip package
            pack.Close();

            Console.ReadKey();
        }
    }
}
