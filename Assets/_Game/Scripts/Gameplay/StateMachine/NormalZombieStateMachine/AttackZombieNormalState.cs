using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackZombieNormalState : IZombieNormalState
{
    public void OnEnter(NormalZombie normalZombie)
    {
        normalZombie.StopMoving();
    }

    public void OnExecute(NormalZombie normalZombie)
    {
        if (!normalZombie.IsDead() && normalZombie.RotateTowardsTarget())
        {
            if (!normalZombie.HasTarget())
            {
                normalZombie.ChangeState(new PartrolNormalZombieState());
            }
            else
            {
                if (!normalZombie.HasTargetInRange())
                {
                    normalZombie.ResetAttackCoolDown();
                    normalZombie.ChangeState(new PartrolNormalZombieState());
                }
            }
            normalZombie.OnAttack();
            // Neu khong co muc tieu
        }
    }

    public void OnExit(NormalZombie normalZombie)
    {
        
    }
}
