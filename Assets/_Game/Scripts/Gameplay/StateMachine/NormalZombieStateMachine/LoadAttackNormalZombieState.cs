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
            attackCoolDown += Time.deltaTime;
            if (attackCoolDown >= normalZombie.AttackSpeed)
            {
                if (!normalZombie.HasTargetInRange())
                {
                    Debug.Log("Change Idle State");
                    normalZombie.ChangeState(new PartrolNormalZombieState());
                }
                if (normalZombie.Target != null && !normalZombie.Target.IsDead())
                {
                    normalZombie.Target.OnHit(normalZombie.Damage);
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
