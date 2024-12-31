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
        // xoay nhan vat ve phia target
        character.RotateTowardsTarget();
        // neu nhan vat chua chet
        if (!character.IsDead)
        {
            // Tan cong
            character.OnAttack();
            // Neu khong co muc tieu
            if(!character.IsTargetInRange())
            {
                character.ChangeState(new MoveState());
                character.ResetAttackCoolDown();
                
            }
            if(character is GunHero gunHero)
            {
                if(!gunHero.HasTarget())
                {
                    gunHero.ChangeState(new IdleState());
                }
            }
        }
            
        
    }


    public void OnExit(Character character)
    {
        
    }
}
