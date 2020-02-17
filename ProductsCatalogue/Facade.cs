using Newtonsoft.Json;
using ProductsCatalogue.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.RepresentationModel;

namespace ProductsCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("---Listing your products---");
            Console.WriteLine();
            if (Convert.ToBoolean(Convert.ToInt32(ConfigurationManager.AppSettings["YamlOrg"])))
                ParseYaml();
            if (Convert.ToBoolean(Convert.ToInt32(ConfigurationManager.AppSettings["JsonOrg"])))
                ParseJson();
            if (Convert.ToBoolean(Convert.ToInt32(ConfigurationManager.AppSettings["CsvOrg"])))
                CsvParser();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Scrol on top to read all & Press any key to close!");

            Console.ReadKey();
        }

        private static void ParseYaml()
        {
            Console.WriteLine("---Listing your product in Yaml File---");
            var path = AppDomain.CurrentDomain.BaseDirectory + "feed-products\\capterra.yaml";

            using (var reader = new StreamReader(path))
            {
                var yaml = new YamlStream();
                yaml.Load(reader);

                List<YamlOrgProduct> lstYamlOrg = new List<YamlOrgProduct>();

                var mapping = yaml.Documents[0].RootNode;

                var child = ((YamlDotNet.RepresentationModel.YamlSequenceNode)mapping).Children;

                int count = 0;
                foreach (var doc in child)
                {
                    count++;
                    Dictionary<YamlNode, YamlNode> map = new Dictionary<YamlNode, YamlNode>();
                    foreach (var item in ((YamlDotNet.RepresentationModel.YamlMappingNode)doc).Children)
                    {
                        map.Add(item.Key, item.Value);

                    }

                    string jsondata = JsonConvert.SerializeObject(map, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

                    var productDetails = JsonConvert.DeserializeObject<YamlOrgProduct>(jsondata);

                    //Project extract data in object
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"-------------PRODUCT extract: {count} (can be used to insert in DB)--------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(productDetails.name.Value);
                    Console.WriteLine(productDetails.tags.Value);
                    Console.WriteLine(productDetails.twitter.Value);

                    //Products detailed data in JSON format
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"---PRODUCT details: {count} IN JSON FORMAT (can be used to send 3rd party api's etc---");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(JsonConvert.SerializeObject(productDetails, Formatting.Indented));

                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Total {count} Products in Yaml File!");
            }
        }
        private static void ParseJson()
        {
            Console.WriteLine($"--------------Product in Json File---------------");
            var path = AppDomain.CurrentDomain.BaseDirectory + "feed-products\\softwareadvice.json";

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();

                var productDetails = JsonConvert.DeserializeObject<JsonOrgProduct>(json);

                //Object "productDetails" can be used to save/use data further
                //Printing them just for view on console
                int count = 0;
                foreach (var items in productDetails.products)
                {
                    count++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"---Product {count} :-----");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(items.title);
                    Console.WriteLine(items.twitter);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Categoris are:");
                    foreach (var item in items.categories)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(item);
                    }
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Total Product {count} in Json file");
            }

        }

        private static void CsvParser()
        {
            Console.WriteLine("CsvParser Called");
            //A new method needs to be added to handle a new file type from a different location
            // we can enable disable them as per need without changing code
        }
    }
}
