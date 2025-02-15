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
            // Danh cho ban xa

            if (!character.HasTarget())
            {
                character.ChangeState(new IdleState());
            }
            else // danh' cho danh gan (neu phat hien co ke dich)
            {
                // Xet xem ke dich co dang trong tam danh khong?
                //
                //Neu ke dich khong trong tam danh => Move
                if(!character.HasTargetInRange())
                {
                    character.ChangeState(new PartrolState());
                }
                else // Neu Ke dich trong tam danh
                {
                    character.OnAttack();
                    character.ChangeState(new LoadAttackState());
                }
               
            }
           
            
        }
    }

    public void OnExit(Character character)
    {
        
    }
}
