#r "Newtonsoft.Json"
#r "TankWar.Core"

using System;
using System.Net;
using Newtonsoft.Json;
using TankWar.Core;
public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"Webhook was triggered!");

    string jsonContent = await req.Content.ReadAsStringAsync();

    var tankService = new TankService();
    TankInfo data = tankService.GetInfo(jsonContent);

    //dynamic data = JsonConvert.DeserializeObject(jsonContent);
    


    if (data.first == null || data.last == null)
    {
        return req.CreateResponse(HttpStatusCode.BadRequest, new
        {
            error = "Please pass first/last properties in the input object"
        });
    }

    return req.CreateResponse(HttpStatusCode.OK, new
    {
        greeting = $"Hello {data.first} {data.last}!"
    });
}
