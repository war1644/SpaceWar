﻿using System;
namespace SpaceWar
{
    class Good
    {
        public readonly string describe;
        public byte quantity=0;
        public readonly string name;
        public int price;

        public Good(string goodName, int goodPrice,string goodDescribe="")
        {
            name = goodName;
            price = goodPrice;
            describe = goodDescribe;
        }

        


    }
}