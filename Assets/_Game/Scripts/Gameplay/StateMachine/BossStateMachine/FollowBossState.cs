using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBossState : IBossState
{
    public void OnEnter(BossZombie bossZombie)
    {

    }

    public void OnExecute(BossZombie bossZombie)
    {
        if (!bossZombie.IsDead())
        {
            bossZombie.OnMove(); //MoveToTarget Update lien tuc de tien toi vi tru cua doi tuong

            // Neu khong co target hoac target chet thi chuyen sang partrol state
            if (!bossZombie.HasTarget())
            {
                bossZombie.ChangeState(new PartrolBossState());
            }
            // neu doi tuong trong tam danh thi => chuyen sang attack State
            if (bossZombie.HasTargetInRange())
            {

                bossZombie.ChangeState(new AttackBossState());
            }
        }
    }

    public void OnExit(BossZombie bossZombie)
    {

    }

}
