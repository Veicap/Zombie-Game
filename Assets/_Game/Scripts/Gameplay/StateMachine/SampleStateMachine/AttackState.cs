using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    public void OnEnter(Character character)
    {
        character.StopMoving();
    }

    public void OnExecute(Character character)
    {
        if (!character.IsDead() && character.RotateTowardsTarget())
        {
            // Tan cong
            character.OnAttack();
            if (!character.HasTarget())
            {
                character.ChangeState(new IdleState());
            }
            else
            {
                if (!character.IsTargetInRange())
                {
                    character.ResetAttackCoolDown();
                    character.ChangeState(new MoveState());
                }
            }
            // Neu khong co muc tieu
        }
    }


    public void OnExit(Character character)
    {
        
    }
}
