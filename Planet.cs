
using System.Collections.Generic;

namespace SpaceWar
{
    public class Planet
    {

        public string name;
        // internal readonly string spaceStation;
        public string galaxy;
        public int x;
        public int y;
        public Good[] goods;
        // public Ship[] ships;
        public List<Ship> fleet;
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
