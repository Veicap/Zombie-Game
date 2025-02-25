using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBossState : IBossState
{
    public void OnEnter(BossZombie bossZombie)
    {
        bossZombie.StopMoving();
    }

    public void OnExecute(BossZombie bossZombie)
    {
        if (!bossZombie.IsDead() && bossZombie.RotateTowardsTarget())
        {

            if (!bossZombie.HasTarget())
            {
                bossZombie.ChangeState(new PartrolBossState());
            }
            else
            {
                // Neu ke dich khong o trong tam danh
                if (!bossZombie.HasTargetInRange())
                {
                    bossZombie.ChangeState(new PartrolBossState());
                }
                else // Neu Ke dich trong tam danh
                {
                    bossZombie.OnAttack();
                    var target = bossZombie.Target;
                    bossZombie.ChangeState(new LoadAttackBossState(target));
                }
            }
        }
    }

    public void OnExit(BossZombie bossZombie)
    {
        
    }
}
