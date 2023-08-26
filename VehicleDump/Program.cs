using System.Xml;
using Newtonsoft.Json;

foreach (string filename in Directory.GetFiles("..\\..\\..\\..\\Vehicles", "vehicles.meta")) //Only use the one from Update.rpf, the DLC ones say they use FLAG_EXTRAS_STRONG but don't actually use any Extras.
{
    XmlDocument doc = new XmlDocument();
    doc.Load(filename);
    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/CVehicleModelInfo__InitDataList/InitDatas/Item");

    var json = File.ReadAllText("..\\..\\..\\..\\Vehicles\\vehicles.json"); //https://raw.githubusercontent.com/DurtyFree/gta-v-data-dumps/master/vehicles.json
    dynamic data = JsonConvert.DeserializeObject(json);

    foreach (XmlNode node in nodes)
    {
        if (node.SelectSingleNode("flags").InnerText.Contains("EXTRA"))
        {
            var modelName = node.SelectSingleNode("modelName").InnerText.ToUpper();
            foreach (var vehicle in data)
            {
                string vehicle_Name = vehicle.Name;
                if (vehicle_Name.ToUpper() == modelName)
                {
                    Console.WriteLine(modelName + " //" + vehicle.DisplayName.English);
                }
            }
        }
    }
}