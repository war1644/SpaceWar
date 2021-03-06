﻿using System;
namespace SpaceWar
{
    public class Ship
    {
        public string name;
        public string describe;
        public int cargo;
        public int speed;
        public int price;
        public int maxFuel;
        public int maxHp;
        public int fuel;
        public int hp;

        public Ship(string shipName,int shipHp, int shipCargo, int shipSpeed, int shipPrice,int shipFuel,string shipDescribe="")
        {
            name = shipName;
            hp = shipHp;
            maxHp = shipHp;
            cargo = shipCargo;
            speed = shipSpeed;
            price = shipPrice;
            fuel = shipFuel;
            maxFuel = shipFuel;
            describe = shipDescribe;
        }
        public Ship()
        {
        }

        public bool CalculateFuel(int fuelValue)
        {
            int tmpFuel = fuel + fuelValue;
            if(tmpFuel<0) return false;
            fuel = tmpFuel;
            return true;
        }

        public bool CalculateHp(int hpValue)
        {
            int tmpHp = hp + hpValue;
            if(tmpHp<0) return false;
            hp = tmpHp;
            return true;
        }

        public void Refuel(Player player)
        {
            int refuelPrice = maxFuel - fuel;
            if (player.credits - refuelPrice < 0)
            {
                Console.WriteLine("没钱加燃料");
            }
            else
            {
                Console.WriteLine($"燃料已加满，花费{refuelPrice}");
                player.AddCredits(-refuelPrice);
                fuel = maxFuel;
            }
        }

        public void Repair(Player player)
        {
            int repairPrice = maxHp - hp;
            if (player.credits - repairPrice < 0)
            {
                Console.WriteLine("没钱修理");
            }
            else
            {
                Console.WriteLine($"修理完成，花费{repairPrice}");
                player.AddCredits(-repairPrice);
                hp = maxHp;
            }
        }

    }
}
