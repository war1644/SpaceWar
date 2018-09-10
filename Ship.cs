using System;
namespace SpaceWar
{
    class Ship
    {
        public readonly string name;
        public readonly string describe;
        public readonly int cargo;
        public readonly int speed;
        public readonly int price;
        public readonly int maxFuel;
        public readonly int maxHp;
        public int currentFuel;
        public int currentHp;

        public Ship(string shipName, int shipCargo, int shipSpeed, int shipPrice,int fuel,string shipDescribe="")
        {
            name = shipName;
            cargo = shipCargo;
            speed = shipSpeed;
            price = shipPrice;
            maxFuel = fuel;
            currentFuel = fuel;
            describe = shipDescribe;
        }

        public void SetCurrentFuel(int fuel)
        {
            currentFuel += fuel;
        }

        public void RefuelShip(Player player)
        {
            int refuelPrice = maxFuel - currentFuel;
            if (player.credits - refuelPrice < 0)
            {
                Console.WriteLine("没钱加燃料");
            }
            else
            {
                Console.WriteLine($"燃料已加满，花费{refuelPrice}");
                player.AddCredits(-refuelPrice);
                currentFuel = maxFuel;
            }
        }

    }
}
