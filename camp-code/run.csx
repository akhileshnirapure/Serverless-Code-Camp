#r "Newtonsoft.Json"
#r "TankWar.Core.dll"

using System;
using System.Net;
using Newtonsoft.Json;
using TankWar.Core;
public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"Tank Info was triggered!");

    string jsonContent = await req.Content.ReadAsStringAsync();

    var tankService = new TankService();
    //var response = tankService.GetInfo();
    var response = tankService.GetCommand(jsonContent);

    return response;

}
