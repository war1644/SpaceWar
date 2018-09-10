
using System.Collections.Generic;

namespace SpaceWar
{
    class Galaxy
    {

        internal readonly string name;
        public List<int> distanceBetweenPlanets = new List<int>();
        internal Dictionary<string,string[]> galaxy = new Dictionary<string, string[]>
        {
            {"* 人马座\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            {"* 烈阳星区\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            {"* 天狼星区\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            {"* 北落师门\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            {"* PLA\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            {"* 北极星区\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
        };

        

    }
}
