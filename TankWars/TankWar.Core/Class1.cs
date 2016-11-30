using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TankWar.Core
{
    public class TankService
    {
        public HttpResponseMessage GetInfo()
        {
            var tankInfo = new TankInfo {name = "AzureTank", owner = "Akhilesh Nirapure"};
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(tankInfo))
            };
            return response;
        }

        public HttpResponseMessage GetCommand(string mapPayLoad)
        {
            var root = JsonConvert.DeserializeObject<RootObject>(mapPayLoad);

            var command = new Command {command = "turn-left"};//default

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(command))
            };
            return response;
        }
    }
}
