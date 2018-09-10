using System;
using System.Threading;
using System.Collections.Generic;
namespace SpaceWar
{
    class Game
    {

        public Good[] goods;
        public Ship[] ships;
        public Player player;
        // public string historyInput;
        static public bool docked = false;
        static public bool isJump = true;
        internal static Random rand = new Random();
        public static string GetInput()
        {
            bool isInput;
            string userInput = "";
            do
            {
                try
                {
                    userInput = Console.ReadLine();
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
            return userInput;
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
            CreateGalaxys();
            Planet planet = Galaxy.list["天狼星区"][0];
            Player player = new Player("路漫漫",9999999,ships[1],planet);

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
                Display.Show("> ");
                userInput = GetInput();
                if(userInput == "buy" && docked)
                {
                    Display.Show(goods);
                    choice = GetChoice();
                    string info = player.BuyGood(goods[choice],5);
                    Display.Show(info);
                }
                else if(userInput == "sell" && docked)
                {
                    Display.ShowIndex(player.goodNameList);
                    choice = GetChoice();
                    string info = player.SellGood(choice);
                    Display.Show(info);
                }
                else if(userInput == "state")
                {
                    Display.Show(player.GetState());
                }
                else if(userInput == "simulator" && docked)
                {
                    
                }
                else if(userInput == "dock")
                {
                    if(!docked)
                    {
                        
                    }
                    else
                    {
                        Display.AutoShow("停泊中");
                    }
                    
                }
                else if(userInput == "save")
                {
                    
                }
                else if(userInput == "load")
                {
                    
                }
                else if(userInput == "jump")
                {
                    if(isJump)
                    {
                        Display.AutoShow("连接星际大门中...", 2000);
                        Display.AutoShow("连接成功，请选择跳跃星系");
                        Display.Show(Galaxy.nameList);
                    }
                    else
                    {
                        Display.Show("ERROR,附近未发现星际大门");
                    }
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

        void CreateGalaxys()
        {
            foreach (var item in Galaxy.nameList)
            {
                Planet[] planet = new Planet[rand.Next(2,5)];
                planet[0] = new Planet("星系跳跃门",item, 0, 0);
                for (int i = 1; i < planet.Length; i++)
                {
                    int planetNumber = rand.Next(1, 500);
                    int x = rand.Next(-50, 50);
                    int y = rand.Next(-50, 50);
                    planet[i] = new Planet($"开发行星{planetNumber}",item,x,y);
                }
                Galaxy.list.Add(item,planet);
            }
        }

    }
}