using System;
namespace SpaceWar
{
    class Battle
    {
        public int aiHp;
        public int playerHp;

        public Battle(Player player)
        {
            Random rand =  Game.rand;
            playerHp = player.ship.hp;
            aiHp = rand.Next(100,player.ship.maxHp);

            int isFirst = rand.Next(1,2);
            int haveGood = rand.Next(0,9);
            string[] weapon = {"导弹","EMP","鱼雷","激光炮","轨道炮"};
            int[] weaponHit = {150,200,300,500,1000};
            int aiWeaponIndex=0;
            while (aiHp > 0 && playerHp > 0)
            {
                int weaponIndex = rand.Next(0,weapon.Length);
                aiWeaponIndex = rand.Next(0,weapon.Length);
                if(isFirst==1){
                    Display.AutoShow("我方沉着应战");
                    Display.AutoShow($"{weapon[weaponIndex]} 齐射！");
                    Display.AutoShow($"敌方躲闪不急");
                    aiHp=0;
                }else{
                    Display.AutoShow("敌人气势汹汹");
                    Display.AutoShow($"{weapon[weaponIndex]} 密集射来！");
                    Display.AutoShow($"我方机体受损");
                    // playerHp -=  weaponHit[aiWeaponIndex];
                    player.ship.CalculateHp(-aiHp);
                    aiHp=0;
                }
            }
            Display.AutoShow($"战斗结束");
            if(haveGood>=8){
                string tmpName = $"飞船零件{aiWeaponIndex}";
                Display.AutoShow($"获得{tmpName}");
                Good good = new Good(tmpName,weaponHit[aiWeaponIndex]*100); 
                player.AddGood(good,1);
            }
        }

        


    }
}
