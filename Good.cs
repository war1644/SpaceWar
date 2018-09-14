using System;
namespace SpaceWar
{
    public class Good
    {
        public readonly string describe;
        public byte quantity=0;
        public readonly string name;
        public int price;
        public int standardPrice;

        public Good(string goodName, int goodPrice,string goodDescribe="")
        {
            name = goodName;
            price = goodPrice;
            standardPrice = goodPrice;
            describe = goodDescribe;
        }

        public Good()
        {
            
        }

//         public object clone()
//         {
//             Good copyGood = new Good(this.name,this.price,this.describe);
//             copyGood.price = this.price;
// 　　　　　　  return copyGood; 
//         }

        


    }
}
