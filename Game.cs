using System;
using System.Threading;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
namespace SpaceWar
{
    public class Game
    {
        static string filePath = "save.xml";

        public Good[] goods;
        public Ship[] ships;
        static public Player player;
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
                    Display.Show("\n> 请输入：");
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
            player = new Player("路漫漫",9999,ships[1],planet);

            string info = player.BuyGood(goods[1],5);
            Display.Show(Menu.help);

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
                if(docked)
                {
                    Display.Show("\n> 已停靠，等待指令中...(帮助请输入'help') ");
                }
                else
                {
                    Display.Show("\n> 等待指令中... (帮助请输入'help')");
                }
                userInput = GetInput();


                if(userInput == "buy" && docked)
                {
                    Good[] planetGoods = player.planet.goods;
                    Display.Show(planetGoods);
                    choice = GetChoice();
                    Good good = planetGoods[choice];
                    Display.Show($"> 买多少的{good.name}？");
                    byte number = GetChoice();
                    string info = player.BuyGood(good,number);
                    Display.Show(info);
                }
                else if(userInput == "sell" && docked)
                {
                    Display.ShowIndex(player.goodNameList);
                    choice = GetChoice();
                    string info = player.SellGood(choice);
                    Display.Show(info);
                }
                else if(userInput == "cargo")
                {
                    Display.Show(player.CargoInventory());
                }
                else if(userInput == "ship" && docked)
                {
                    Display.Show(ships);
                    choice = GetChoice();
                    string info = player.BuyShip(ships[choice]);
                    Display.Show(info);
                }
                else if(userInput == "help")
                {
                    if(docked){
                        Display.Show(Menu.docked);
                    }else{
                        Display.Show(Menu.help);
                    }
                }
                else if(userInput == "state")
                {
                    Display.Show(player.GetState());
                }
                else if(userInput == "refuel" && docked)
                {
                    player.ship.Refuel(player);
                }
                else if(userInput == "repair" && docked)
                {
                    player.ship.Repair(player);
                }
                else if(userInput == "upgrade" && docked)
                {
                    
                }
                else if(userInput == "simulator" && docked)
                {
                    new Battle(player);
                }
                else if(userInput == "dock" && !docked)
                {
                    if(player.planet.name != "星系跳跃门")
                    {
                        Display.AutoShow("已发出停靠请求");
                        Display.AutoShow("获得停靠许可，开始停靠...");
                        docked = true;
                        Display.AutoShow("停靠完成");
                    }
                }
                else if(userInput == "goto" && !docked)
                {
                    string galaxyName = player.planet.galaxy;
                    Planet[] planets = Galaxy.list[galaxyName];
                    Display.Show("请选择目标星球：");
                    Display.Show(planets);
                    choice = GetChoice();
                    Display.AutoShow("锁定目标星球，开始巡航...");
                    int battle = rand.Next(0,9);
                    if(battle>5){
                        new Battle(player);
                    }
                    bool success = player.SetGoToPlant(planets[choice]);
                    if(success)
                    {
                        Display.AutoShow($"到达 {planets[choice].name}");
                    }
                    else
                    {
                        Display.AutoShow($"距离过远，需要更多的燃料");
                    }
                }
                else if(userInput == "undock" && docked)
                {
                    Display.AutoShow("飞船已升空");
                    docked = false;
                }
                else if(userInput == "save")
                {
                    Save(this);
                }
                else if(userInput == "load")
                {
                    Load();
                }
                else if(userInput == "jump" && !docked)
                {
                    if(isJump)
                    {
                        Display.AutoShow("连接星际大门中...");
                        Display.AutoShow("连接成功，请选择跳跃星系");
                        Display.ShowIndex(Galaxy.showNameList);
                        choice = GetChoice();
                        string galaxyName = Galaxy.nameList[choice];
                        if(galaxyName == player.planet.galaxy)
                        {
                            Display.AutoShow("ERROR,不能选择当前星区");
                        }
                        else
                        {
                            Display.AutoShow("开始跃迁...");
                            Planet planet = Galaxy.list[galaxyName][0];
                            player.SetPlant(planet);
                            Display.AutoShow($"跃迁完成，欢迎来到 {galaxyName} ");
                        }
                    }
                    else
                    {
                        Display.Show("ERROR,附近未发现星际大门");
                    }
                }
                else if(userInput == "exit")
                {
                    Display.AutoShow("关闭中...");
                    isWhile = false;
                }
                else if(userInput == "map")
                {
                    Display.Show(Galaxy.map());
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
                new Good("矿石", 30),
                new Good("武器", 60),
                new Good("木材", 10),
                new Good("铜", 50),
                new Good("暗物质", 450000),
                new Good("生活包", 500),
            };
        }

        void CreateShips()
        {
            ships = new Ship[]
            {
                new Ship("采矿船",1000, 150, 3, 100000, 25),
                new Ship("轻型货机",500, 50, 3, 25000, 20),
                new Ship("PLA战斗机",300, 300, 4, 75000, 20),
                new Ship("CR90轻巡洋舰",3000, 750, 7, 125000, 30),
                new Ship("PLA巡洋舰",5000, 50, 9, 400000, 40),
                new Ship("帝国驱逐舰",50000, 1000, 7, 500000, 50),
                new Ship("帝国歼星舰",100000, 2000, 5, 1000000, 100),
            };
        }
        void CreateGalaxys()
        {
            foreach (var galaxyName in Galaxy.nameList)
            {
                Planet[] planet = new Planet[rand.Next(5,9)];
                planet[0] = new Planet("星系跳跃门",galaxyName, 0, 0);

                //设置跳跃门舰队（星系主力舰队）
                List<Ship> masterFleet1 = SetRandomFleet();
                List<Ship> masterFleet2 = SetRandomFleet();
                masterFleet1.AddRange(masterFleet2);
                planet[0].fleet = masterFleet1;

                for (int i = 1; i < planet.Length; i++)
                {
                    int planetNumber = rand.Next(1, 500);
                    int x = rand.Next(-50, 50);
                    int y = rand.Next(-50, 50);
                    int xDistance = x - planet[0].x;
                    int yDistance = y - planet[0].y;
                    int distance = xDistance + yDistance;
                    planet[i] = new Planet($"开发行星{planetNumber}",galaxyName,x,y);
                    //设置市场价
                    Good[] localGoods = SetRandomGoodsPrice();
                    planet[i].goods = localGoods;
                    planet[i].distance = distance;

                    //设置星球护卫舰队
                    List<Ship> localFleet = SetRandomFleet();
                    planet[i].fleet = localFleet;
                }
                Galaxy.list.Add(galaxyName,planet);
            }
        }

        //各星球价格随机，形成差价
        Good[] SetRandomGoodsPrice()
        {
            Good[] tmpGoods = new Good[goods.Length]; 

            for (int i = 0; i < goods.Length; i++)
            {
                tmpGoods[i] = Clone<Good>(goods[i]);
                tmpGoods[i].price = rand.Next(tmpGoods[i].price/10, tmpGoods[i].price);
            }
            return tmpGoods;

        }

        //为各星球生成舰队
        List<Ship> SetRandomFleet()
        {
            int tmpNumber = rand.Next(1,9);
            List<Ship> tmpShips = new List<Ship>();
            for (int i = 0; i < tmpNumber; i++)
            {
                int tmpRand = rand.Next(2,ships.Length);
                tmpShips.Add(Clone<Ship>(ships[tmpRand]));
            }
            return tmpShips;

        }

        //对象深拷贝
        public static T Clone<T>(T RealObject) 
        {  
            using(Stream stream=new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, RealObject);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)serializer.Deserialize(stream);
            }
        }

        //游戏存储
        public static void Save<T>(T RealObject) 
        {  
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(fs, RealObject);
            }
        }

        public static T Load<T>() 
        {  
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(fs);
            }
        }

       

    }
}