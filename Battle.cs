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
            int haveGood = rand.Next(0,10);
            string[] weapon = {"导弹","EMP","鱼雷","激光炮","轨道炮"};
            int[] weaponHit = {50,80,150,500,1000};
            int aiWeaponIndex=0;
            while (aiHp > 0 && playerHp > 0)
            {
                int weaponIndex = rand.Next(0,weapon.Length);
                aiWeaponIndex = rand.Next(0,weapon.Length);
                if(isFirst==1){
                    Display.Show("我方沉着应战");
                    Display.Show($"{weapon[weaponIndex]} 发射！");
                    Display.Show($"敌机躲闪不急，被击中");
                    aiHp=0;
                }else{
                    Display.Show("敌人气势汹汹");
                    Display.Show($"{weapon[weaponIndex]} 密集射来！");
                    Display.Show($"我方机体受损，装甲减少{weaponHit[aiWeaponIndex]}");
                    aiHp=0;
                }
            }

            if(haveGood>=7){
                string tmpName = $"飞船零件{aiWeaponIndex}";
                Display.Show($"获得{tmpName}");
                Good good = new Good(tmpName,weaponHit[aiWeaponIndex]*10); 
                player.AddGood(good,1);
            }
        }

        


    }
}
