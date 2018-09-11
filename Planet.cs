
using System.Collections.Generic;

namespace SpaceWar
{
    class Planet
    {

        internal readonly string name;
        // internal readonly string spaceStation;
        internal readonly string galaxy;
        internal readonly int x;
        internal readonly int y;
        public Good[] goods;
        public int distance;
        


        public Planet(string plantName,string galaxyName,int xCordinate,int yCordinate)
        {
            name = plantName;
            x = xCordinate;
            y = yCordinate;
            galaxy = galaxyName;
        }

    }
}
