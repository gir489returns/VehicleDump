using Newtonsoft.Json;

HttpClient client = new HttpClient();
string vehicleJson = await client.GetStringAsync("https://raw.githubusercontent.com/DurtyFree/gta-v-data-dumps/master/vehicles.json");

dynamic data = JsonConvert.DeserializeObject(vehicleJson);

foreach (var vehicle in data)
{
    if ( vehicle.Extras.Count > 0)
    {
        string vehicle_Name = vehicle.Name;
        Console.WriteLine(vehicle_Name.ToUpper() + " //" + vehicle.DisplayName.English);
    }
}