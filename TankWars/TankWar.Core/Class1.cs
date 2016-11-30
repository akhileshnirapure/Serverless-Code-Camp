using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TankWar.Core
{
    public class TankService
    {
        public TankInfo GetInfo(string jsonPayLoad)
        {
            return JsonConvert.DeserializeObject<TankInfo>(jsonPayLoad);
        } 
    }
}
