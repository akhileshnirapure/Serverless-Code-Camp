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
        public TankService()
        {
            
        }

        public TankService(RootObject root)
        {
            _root = root;
            _enemy = root.enemies.First();
        }
        private RootObject _root;
        private Enemy _enemy;

        public HttpResponseMessage GetInfo()
        {
            var tankInfo = new TankInfo { name = "AzureTank", owner = "Akhilesh Nirapure" };
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(tankInfo))
            };
            return response;
        }

        public HttpResponseMessage GetCommand(string command)
        {

            var nextCommand = new Command { command = command };//default

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(nextCommand))
            };
            return response;
        }

        double CalculateDistance(Point enemy, Point me)
        {
            var result = Math.Pow(enemy.x - me.x, 2) + Math.Pow(enemy.y - enemy.y, 2) ;
            
            return result;
        }

        public bool IsClose()
        {
            var me = _root.you;
            return
                _root.enemies.Any(
                    p => CalculateDistance(new Point {x = p.x, y = p.y}, new Point {x = me.x, y = me.y}) > 0);
        }

        public double GetDistanceFromEnemy()
        {
            var me = _root.you;
            var enemy = _enemy;
            return CalculateDistance(new Point { x = enemy.x, y = enemy.y }, new Point { x = me.x, y = me.y });
        }


        public bool DoBothFaceEachOther()
        {
            if(_root.you.direction == "right" && _enemy.direction == "left") return true;
            if (_root.you.direction == "left" && _enemy.direction == "right") return true;

            return false;
        }

        public string MoveForward()
        {
            return "forward";
        }

        public string MoveReverse()
        {
            return "reverse";
        }

        public string Fire()
        {
            return "fire";
        }

        public string Pass()
        {
            return "pass";
        }

        public HttpResponseMessage Action()
        {
            if (GetDistanceFromEnemy() > 0 && DoBothFaceEachOther())
            {
                return GetCommand(MoveForward());
            }

            return GetCommand(Pass());
        }
    }
}
