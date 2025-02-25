using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBossState : IBossState
{
    public void OnEnter(BossZombie bossZombie)
    {
        bossZombie.ChangeAnimation(Constants.ANIM_POWER_UP);
    }
    public void OnExecute(BossZombie bossZombie)
    {
         
    }
    public void OnExit(BossZombie bossZombie)
    {

    }

}
