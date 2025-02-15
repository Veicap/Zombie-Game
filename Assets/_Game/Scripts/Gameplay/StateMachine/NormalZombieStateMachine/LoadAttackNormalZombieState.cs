using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LoadAttackNormalZombieState : IZombieNormalState
{
    float attackCoolDown = 0f;
    public void OnEnter(NormalZombie normalZombie)
    {
        
    }

    public void OnExecute(NormalZombie normalZombie)
    {
        if(!normalZombie.IsDead())
        {
            if (!normalZombie.HasTargetInRange())
            {
                // Debug.Log("Change Move State");
                normalZombie.ChangeState(new PartrolState());
            }
            else
            {
                attackCoolDown += Time.deltaTime;
                //Debug.Log(attackCooldown);
                if (attackCoolDown >= normalZombie.AttackSpeed)
                {
                    if (normalZombie.Target != null && !normalZombie.Target.IsDead())
                    {
                        normalZombie.Target.OnHit(normalZombie.Damage);
                    }
                    attackCoolDown = 0f;
                    normalZombie.ChangeState(new AttackState());
                }
            }
        }
        
    }
    public void OnExit(NormalZombie normalZombie)
    {
        
    }
}
