using System;
using System.Threading;
namespace SpaceWar
{
    class Game
    {

        public Good[] goods;
        public Ship[] ships;
        public Player player;
        // public string historyInput;
        public bool docked = false;
        internal static Random rand = new Random();
        internal Dictionary<string,string[]> galaxy = new Dictionary<string, string[]>
        {
            {"* 人马座\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            {"* 烈阳星区\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            {"* 天狼星区\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            {"* 北落师门\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            {"* PLA\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            {"* 北极星区\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
        };

        public static string GetInput()
        {
            string choice="";
            bool isInput;
            do
            {
                try
                {
                    choice = Console.ReadLine();
                    isInput = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("无效输入");
                    isInput = true;
                }
                Thread.Sleep(100);
            } while (isInput);
            Console.Clear();
            return choice;
        }

        public static byte GetChoice()
        {
            byte choice=0;
            bool isInput;
            do
            {
                try
                {
                    choice = byte.Parse(Console.ReadLine());
                    isInput = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("无效输入");
                    isInput = true;
                }
                Thread.Sleep(100);
            } while (isInput);
            Console.Clear();
            return choice;
        }

        public Game()
        {
            CreateGoods();
            CreateShips();

            player = new Player("路漫漫",9999999,ships[1]);

            string info = player.BuyGood(goods[1],5);
            test();

            
            // ProcessLogic(userInput);
            
        }

            
        public void test()
        {
            byte choice;
            bool isWhile = true;
            string userInput; 
            do
            {
                userInput = Display.Show("> ");
                if(userInput == "buy")
                {
                    userInput = Display.Show(goods);
                    choice = byte.Parse(userInput);
                    string info = player.BuyGood(goods[choice],5);
                    Display.Show(info);
                }
                else if(userInput == "sell")
                {
                    userInput = Display.ShowIndex(player.goodNameList);
                    choice = byte.Parse(userInput);
                    string info = player.SellGood(choice);
                    Display.Show(info);
                }
                else if(userInput == "state")
                {
                    
                }
                else if(userInput == "simulator")
                {
                    
                }
                else if(userInput == "dock")
                {
                    
                }
                else if(userInput == "save")
                {
                    
                }
                else if(userInput == "load")
                {
                    
                }
                else if(userInput == "jump")
                {
                    
                }
                else if(userInput == "exit")
                {
                    isWhile = false;
                }

                Thread.Sleep(100);

            } while (isWhile);

        }

        public void ProcessLogic(string userInput)
        {
            
        }

        void CreateGoods()
        {
            goods = new Good[]
            {
                new Good("营养液", 200),
                new Good("金", 12000),
                new Good("钻石", 1400),
                new Good("矿石", 70),
                new Good("武器", 66),
                new Good("木材", 2),
                new Good("铜", 10),
                new Good("暗物质", 450000),
                new Good("生活包", 500),
            };
        }

        void CreateShips()
        {
            ships = new Ship[]
            {
                new Ship("采矿船", 150, 3, 100000, 25),
                new Ship("轻型货机", 50, 3, 25000, 10),
                new Ship("PLA战斗机", 300, 4, 75000, 20),
                new Ship("CR90轻巡洋舰", 750, 7, 125000, 30),
                new Ship("PLA巡洋舰", 50, 9, 400000, 40),
                new Ship("帝国驱逐舰", 1000, 7, 500000, 50),
                new Ship("帝国歼星舰", 2000, 5, 1000000, 100),
            };
        }

        void CreatePlanets()
        {
            string[] galaxys = {
                "* 人马座\n|",
                "* 烈阳星区\n|",
                "* 天狼星区\n|",
                "* 北落师门\n|",
                "* PLA\n|",
                "* 北极星区\n|"
            };
            foreach (var item in galaxys)
            {
                
            }
            Planet[] planet = new Planet[rand.Next(2,5)];
            planet[0] = new Planet("星系跳跃门", 0, 0);
            for (int i = 1; i < planet.Length; i++)
            {
                int planetNumber = rand.Next(1, 500);
                planet[i] = new Planet($"Planet{planetNumber}", $"Trader{planetNumber}",
                    (rand.Next(-50, 50)+rand.NextDouble()),
                    (rand.Next(-50, 50)+rand.NextDouble()));
            }
            return planet;
        }

    }
}