using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TankWar.Core;

namespace TankWars.Test
{
    [TestClass]
    public class UnitTest1
    {
        private TankService _service;

        [TestInitialize]
        public void Init()
        {
            var result = File.ReadAllText(@"C:\Users\LocalAdmin\Source\Repos\Serverless-Code-Camp\TankWars\TankWars.Test\result.json");

            _service = new TankService(result);
        }

        [TestMethod]
        public void IsCloseTest()
        {
            Console.WriteLine(_service.GetDistanceFromEnemy());

            Console.WriteLine(_service.DoBothFaceEachOther());

            Console.WriteLine(_service.MoveForward());

            Console.WriteLine(_service.Action());

            _service.IsClose();
        }
    }
}
