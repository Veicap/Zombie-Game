using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAttackBossState : IBossState
{
    float attackCoolDown = 0f;
    private ITarget target;

    public LoadAttackBossState(ITarget target)
    {
        this.target = target;
    }
    public void OnEnter(BossZombie bossZombie)
    {

    }

    public void OnExecute(BossZombie bossZombie)
    {
        if (!bossZombie.IsDead())
        {
            attackCoolDown += Time.deltaTime;
            if (attackCoolDown >= bossZombie.AttackSpeed)
            {
                if (!bossZombie.HasTargetInRange())
                {
                    bossZombie.ChangeState(new PartrolBossState());
                }
                if (target != null && !target.IsDead())
                {
                    target.OnHit(bossZombie.Damage);
                }
                attackCoolDown = 0f;
                bossZombie.ChangeState(new AttackBossState());
            }
        }
    }

    public void OnExit(BossZombie bossZombie)
    {

    }
}
