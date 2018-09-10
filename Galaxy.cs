
using System.Collections.Generic;

namespace SpaceWar
{
    class Galaxy
    {
        internal static Dictionary<string,Planet[]> list = new Dictionary<string, Planet[]>();

        static internal string[] nameList = {
            "人马座",
            "烈阳星区",
            "天狼星区",
            "北落师门",
            "PLA",
            "北极星区"
        };

        static internal string[] showNameList = {
            "* 人马座\n|",
            "* 烈阳星区\n|",
            "* 天狼星区\n|",
            "* 北落师门\n|",
            "* PLA\n|",
            "* 北极星区\n|"
        };

        static public List<string> GetPlantNameList(string indexKey)
        {
            Planet[] planet = Galaxy.list[indexKey];
            var inventory = new List<string>();

            foreach (var item in planet)
            {
                inventory.Add($"星球名：{item.name}，位置：[{item.x},{item.y}]");
            }
            return inventory;
        }

        

    }
}
