using System;
using System.Collections.Generic;
namespace SpaceWar
{
    class Display
    {       
        public static string Show(string[] menu)
        {
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
            return Game.GetInput();
        }
        public static string Show(List<string> menu)
        {
            byte indexKey = 0;
            foreach (var item in menu)
            {
                Console.WriteLine($"{indexKey} {item}");
                indexKey++;
            }
            return Game.GetInput();
        }   
        public static string Show(string str)
        {
            Console.WriteLine(str);
            return Game.GetInput();
        }

        public static string Show(Good[] goods)
        {
            byte indexKey = 0;
            foreach (var item in goods)
            {
                Console.WriteLine($"{indexKey} {item.name}");
                indexKey++;
            }
            return Game.GetInput();
        }

        public static string Show(Ship[] ships)
        {
            byte indexKey = 0;
            foreach (var item in ships)
            {
                Console.WriteLine($"{indexKey} {item.name}");
                indexKey++;
            }
            return Game.GetInput();
        }

        public static string ShowIndex(string[] menu)
        {
            byte indexKey = 0;
            foreach (var item in menu)
            {
                Console.WriteLine($"{indexKey} {item}");
                indexKey++;
            }
            return Game.GetInput();
        }



    }
}