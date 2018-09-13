using System;
using System.Collections.Generic;
using System.Threading;
namespace SpaceWar
{
    internal class Display
    {       
        public static void Show(string[] menu)
        {
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
        }
        public static void Show(List<string> menu)
        {
            byte indexKey = 0;
            foreach (var item in menu)
            {
                Console.WriteLine($"{indexKey} {item}");
                indexKey++;
            }
        }   
        public static void Show(string str)
        {
            Console.WriteLine(str);
        }

        public static void AutoShow(string str, int time = 1000)
        {
            Console.WriteLine(str);
            Thread.Sleep(time);
        }

        public static void Show(Good[] goods)
        {
            byte indexKey = 0;
            foreach (var item in goods)
            {
                Console.WriteLine($"{indexKey} {item.name} {item.price} {(item.price/item.standardPrice)}");
                indexKey++;
            }

        }
        public static void Show(Planet[] planets)
        {
            byte indexKey = 0;
            foreach (var item in planets)
            {
                int distance = Math.Abs(item.distance - Game.player.planet.distance);
                Console.WriteLine($"{indexKey} {item.name}，坐标：({item.x},{item.y})，距离：{distance}");
                indexKey++;
            }
        }

        public static void Show(Ship[] ships)
        {
            byte indexKey = 0;
            foreach (var item in ships)
            {
                Console.WriteLine($"{indexKey} {item.name}");
                indexKey++;
            }
        }

        public static void ShowIndex(string[] menu)
        {
            byte indexKey = 0;
            foreach (var item in menu)
            {
                Console.WriteLine($"{indexKey} {item}");
                indexKey++;
            }
        }



    }
}