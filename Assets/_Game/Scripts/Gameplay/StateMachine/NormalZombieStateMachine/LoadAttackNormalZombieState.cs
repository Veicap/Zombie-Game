using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LoadAttackNormalZombieState : IZombieNormalState
{
    float attackCoolDown = 0f;
    private readonly ITarget target;

    public LoadAttackNormalZombieState(ITarget target)
    {
        this.target = target;
    }

    public void OnEnter(NormalZombie normalZombie)
    {
        
    }

    public void OnExecute(NormalZombie normalZombie)
    {
        if(!normalZombie.IsDead())
        {
            attackCoolDown += Time.deltaTime;
            if (attackCoolDown >= normalZombie.AttackSpeed)
            {
                if (!normalZombie.HasTargetInRange())
                {
                    Debug.Log("Change Idle State");
                    normalZombie.ChangeState(new PartrolNormalZombieState());
                }
                if (target != null && !target.IsDead())
                {
                    target.OnHit(normalZombie.Damage);
                }
                attackCoolDown = 0f;
                normalZombie.ChangeState(new AttackZombieNormalState());
            }
        }
    }
    public void OnExit(NormalZombie normalZombie)
    {
        
    }
}
