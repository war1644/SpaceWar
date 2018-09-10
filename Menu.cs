using System;
using System.Collections.Generic;

namespace SpaceWar
{
    class Menu
    {       
            public static string[] start = {
                "--自由枪奇兵--",
                "1 开始",
                "2 载入",
                "3 帮助"
            };

            public static string[] help = {
                "--帮助菜单--",
                "navigation - 显示导航信息，规划航线",
                "jump - 仅在‘星系跳跃大门‘可用，进入其他星系",
                "dock - 停靠附近空间站",
                "state - 显示当前状态",
                "data - 显示星球资料",
                "save - 保存游戏",
                "load - 载入游戏",
                "quit - 退出",
            };
            public static string[] docked = {
                "--停机坪--",
                "repair - 修理",
                "refuel - 加燃料",
                "order ship - 购买飞船",
                "order upgrades - 升级飞船",
                "market - 市场",
                "simulator - 模拟战斗测试",
                "undock - 离开"
            };
            
            public static string[] navigation = {
                "--导航菜单--",
                "1 本地系统",
                "2 星系地图"
            };

            public static string[] menuGalaxy = {
                "---星系地图---",
                "* 人马座",
                "|",
                "* 烈阳星区",
                "|",
                "* 天狼星区",
                "|",
                "* 北落师门",
                "|",
                "* PLA",
                "|",
                "* 北极星区"
            };

            internal Dictionary<string,string[]> galaxy = new Dictionary<string, string[]>
            {
                {"* 人马座\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
                {"* 烈阳星区\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
                {"* 天狼星区\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
                {"* 北落师门\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
                {"* PLA\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
                {"* 北极星区\n|",new string[]{"1 开发行星A","2 空间站","3 开发行星B","|","4 星系跳跃门"}},
            };

            public static string[] menuGalaxySystem = {
                "---星系系统---",
                "1 开发行星A",
                "|",
                "2 空间站",
                "|",
                "3 开发行星B",
                "|",
                "4 星系跳跃门"
            };


    }
}