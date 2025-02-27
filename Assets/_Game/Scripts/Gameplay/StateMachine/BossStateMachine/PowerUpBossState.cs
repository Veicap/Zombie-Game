using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PowerUpBossState : IBossState
{
    float count = 0;
    bool isRivied = false;
    public void OnEnter(BossZombie bossZombie)
    {
        count = 0;
        isRivied = false;
        bossZombie.StopMoving();
        bossZombie.ChangeAnimation(Constants.ANIM_POWER_UP);
    }
    public void OnExecute(BossZombie bossZombie)
    {
        count += Time.deltaTime;
        if(!isRivied && count > 0.8f)
        {
            bossZombie.SpawnAttackEffect();
            bossZombie.OnRivise(500);
            isRivied = true;

        }
        if (count > 1.8f)
        {
            bossZombie.ChangeState(new IdleBossState());
        }
    }
    public void OnExit(BossZombie bossZombie)
    {

    }

}
