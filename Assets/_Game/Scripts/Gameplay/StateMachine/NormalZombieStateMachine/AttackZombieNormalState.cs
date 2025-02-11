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
            // Tan cong
            normalZombie.OnAttack();
            if (!normalZombie.IsTargetInRange())
            {
                normalZombie.ResetAttackCoolDown();
                normalZombie.ChangeState(new MoveState());
            }
            // Neu khong co muc tieu
        }
    }

    public void OnExit(NormalZombie normalZombie)
    {
        
    }
}
