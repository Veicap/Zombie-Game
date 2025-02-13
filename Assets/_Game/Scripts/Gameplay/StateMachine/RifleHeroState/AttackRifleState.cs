using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackRifleState : IRifleState
{
    public void OnEnter(RifleHero rifleHero)
    {
        rifleHero.StopMoving();
    }

    public void OnExecute(RifleHero rifleHero)
    {
        
        // neu nhan vat chua chet
        if (!rifleHero.IsDead() && rifleHero.RotateTowardsTarget())
        {
            // Tan cong
            rifleHero.OnAttack();
            if (!rifleHero.HasTarget())
            {
                rifleHero.ChangeState(new IdleRifleState());
            }
            else
            {
                if (!rifleHero.HasTargetInRange())
                {
                    rifleHero.ResetAttackCoolDown();
                    rifleHero.ChangeState(new MoveRifleState());
                }
            }
            // Neu khong co muc tieu
        }
    }

    public void OnExit(RifleHero rifleHero)
    {
        
    }
}
