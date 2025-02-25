using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBossState : IBossState
{
    public void OnEnter(BossZombie bossZombie)
    {
        bossZombie.ChangeToIdleState();
    }

    public void OnExecute(BossZombie bossZombie)
    {
        if (!bossZombie.IsDead())
        {
            bossZombie.ChangeState(new PartrolBossState());
        }
    }

    public void OnExit(BossZombie bossZombie)
    {

    }
}
