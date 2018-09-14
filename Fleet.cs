
using System.Collections.Generic;

namespace SpaceWar
{
    class Fleet
    {
        internal static Dictionary<string,Ship[]> list = new Dictionary<string, Ship[]>();


        static internal string[] showNameList = {
            "* 人马座\n|    --主力舰队\n    --护卫舰队\n    --巡逻舰队",
            "* 烈阳星区\n|    --主力舰队\n    --护卫舰队\n    --巡逻舰队",
            "* 天狼星区\n|    --主力舰队\n    --护卫舰队\n    --巡逻舰队",
            "* 北落师门\n|    --主力舰队\n    --护卫舰队\n    --巡逻舰队",
            "* PLA\n|    --主力舰队\n    --护卫舰队\n    --巡逻舰队",
            "* 北极星区\n|    --主力舰队\n    --护卫舰队\n    --巡逻舰队"
        };

        static public List<string> GetFleetNameList(string indexKey)
        {
            Ship[] planet = Fleet.list[indexKey];
            var inventory = new List<string>();

            // foreach (var item in planet)
            // {
            //     inventory.Add($"星球名：{item.name}，位置：[{item.x},{item.y}]");
            // }
            return inventory;
        }

        

    }
}
