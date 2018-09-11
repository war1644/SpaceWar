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
         public int maxCargo = 50;
         Ship ship;


        public string[] GetState ()
        {
            return new string[]
            {
                "--状态--",
                $"Money：{credits}，旅行时间： {year} 年 {day} 天",
                $"当前位置：{planet.galaxy} -- {planet.name}，剩余燃料： {ship.fuel}",
                $"飞行状态：{(!Game.docked).ToString()}",
                $"杀敌：{kill}"
            };
        }

        public void CalculateYears()
        {
            if (day > 365) {
                day -= 365;
                year += 1;
            }
        }

        public Player(string userName,int money,Ship shipValue,Planet planet)
        {
            name = userName;
            credits = money;
            ship = shipValue;
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

        internal string TryBuyShip(Ship[] ships)
        {
            int choice;
            do
            {
                choice = int.Parse(Game.GetInput());
            } while (choice < 0);
            if (choice == 0)
            {
                return "想想还是算了";
            }
            if (credits + ship.price >= ships[choice].price)
            {
                AddCredits(ship.price);
                AddCredits(-ships[choice].price);
                ship = ships[choice];
                maxCargo = ship.cargo;
                return "新船入手";
            }
            return "没钱";
        }

        internal string SellGood(byte index)
        {
            string name = goodNameList[index];
            var totalPrice = cargo[name].price * cargo[name].quantity;
            RemoveCargoGood(name);
            AddCredits(totalPrice);
            return $"{name} 已卖";
        }

        public string BuyGood(Good good, byte buyQuantity)
        {
            int totalPrice = good.price * buyQuantity;
            int surplus = maxCargo - cargo.Count;
            if (credits >= totalPrice && good.quantity <= surplus)
            {
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
