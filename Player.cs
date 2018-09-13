using System;
using System.Linq;
using System.Collections.Generic;

namespace SpaceWar
{
    internal class Player
    {
         readonly string name;
         public int credits=0;
         public int year=0;
         public int day=0;
         public int kill=0;
         internal Planet planet;
         //货物仓库
         public Dictionary<string,Good> cargo = new Dictionary<string,Good>();
         public string[] goodNameList;
         public int goodsCount = 0;
         public Ship ship;


        public string[] GetState ()
        {
            return new string[]
            {
                "--状态--",
                $"Money：{credits}，旅行时间： {year} 年 {day} 天",
                $"位置：{planet.galaxy} -- {planet.name}，旗舰：{ship.name}",
                $"燃料： {ship.fuel}，飞行状态：{(!Game.docked).ToString()}",
                $"杀敌：{kill}",
                $"空余货仓：{(ship.cargo-goodsCount)}",

            };
        }

        public void CalculateYears()
        {
            if (day > 365) {
                day -= 365;
                year += 1;
            }
        }

        public Player(string userName,int money,Ship newShip,Planet planet)
        {
            name = userName;
            credits = money;
            ship = newShip;
            SetPlant(planet);
        }



        public void AddCredits(int credit)
        {
            credits += credit;
        }


        public bool SetGoToPlant(Planet toPlanet)
        {
            int distance = CalculatePlanetsDistance(toPlanet);

            if(ship.CalculateFuel(distance))
            {
                day += (distance/ship.speed) <= 0 ? 1 : (distance/ship.speed);
                CalculateYears();
                SetPlant(toPlanet);
                return true;
            }
            return false;
            
        }

        public void SetPlant(Planet toPlanet)
        {
            planet = toPlanet;
            if(planet.name == "星系跳跃门")
            {
                Game.docked = false;
                Game.isJump = true;
            }
            else
            {
                Game.docked = false;
                Game.isJump = false;
            }
        }

        public int CalculatePlanetsDistance(Planet toPlanet)
        {
            if(toPlanet.name == "星系跳跃门")
            {
                return Math.Abs(planet.distance);
            }
            return Math.Abs(toPlanet.distance - planet.distance);
        }
    

        public void AddCargoGood(Good good)
        {
            if(cargo.ContainsKey(good.name))
            {
                cargo[good.name].quantity += good.quantity;
            }
            else
            {
                cargo.Add(good.name,good);
            }
            goodNameList = cargo.Keys.ToArray();
            // Console.WriteLine($"name: {good.name}, quantity: {cargo[good.name].quantity}");
        }

        public void RemoveCargoGood(string goodName)
        {
            cargo.Remove(goodName);
        }

        internal string BuyShip(Ship newShip)
        {
            if ((credits + ship.price) >= newShip.price)
            {
                //买小船,抛弃货物
                if(goodsCount < newShip.cargo)
                {
                    foreach (KeyValuePair<string,Good> item in cargo)
                    {
                        goodsCount -= item.Value.quantity;
                        RemoveCargoGood(item.Key);
                        if(goodsCount <= newShip.cargo){
                            break;
                        }
                    }
                }

                AddCredits(ship.price);
                AddCredits(-newShip.price);
                ship = newShip;
                return "新船入手";
            }
            return "没钱";
        }

        internal string SellGood(byte index)
        {
            string tmpName = goodNameList[index];
            if(!cargo.ContainsKey(tmpName))
            {
                return "没有这个货物";
            }
            Good good = cargo[tmpName];
            int totalPrice = good.price * good.quantity;
            goodsCount -= good.quantity;
            RemoveCargoGood(tmpName);
            AddCredits(totalPrice);
            return $"{name} 已卖";
        }

        public string BuyGood(Good good, byte buyQuantity)
        {
            int totalPrice = good.price * buyQuantity;
            int surplus = ship.cargo - goodsCount;
            if (credits >= totalPrice && good.quantity <= surplus)
            {
                goodsCount += buyQuantity;
                good.quantity = buyQuantity;
                AddCargoGood(good);
                AddCredits(-(totalPrice));
                return "购买成功";
            }

            if (credits < totalPrice)
            {
                return "钱不够";
            }

            return "货仓空间不够";
            
        }
        public string AddGood(Good good, byte buyQuantity)
        {
            int surplus = ship.cargo - goodsCount;
            if (good.quantity <= surplus)
            {
                goodsCount += buyQuantity;
                good.quantity = buyQuantity;
                AddCargoGood(good);
                return "已存入货仓";
            }
            return "货仓空间不够";
            
        }

        public List<string> CargoInventory ()
        {
            var inventory = new List<string>();

            foreach (var item in cargo)
            {
                inventory.Add($"物品名：{item.Value.name}，库存：{item.Value.quantity}");
            }
            return inventory;
        }

    }
}
