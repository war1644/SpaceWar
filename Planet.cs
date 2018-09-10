
using System.Collections.Generic;

namespace SpaceWar
{
    class Planet
    {

        internal readonly string name;
        internal readonly string spaceStation;
        internal readonly string galaxy;
        internal readonly int x;
        internal readonly int y;
        public List<int> distanceBetweenPlanets = new List<int>();


        public Planet(string plantName,int xCordinate,int yCordinate)
        {
            name = plantName;
            x = xCordinate;
            y = yCordinate;
        }

        
        public void SetDistanceToPlanet(int distance)
        {
            distanceBetweenPlanets.Add(distance);
        }

        public List<int> GetDistanceToPlanet()
        {
            return distanceBetweenPlanets;
        }

    }
}
