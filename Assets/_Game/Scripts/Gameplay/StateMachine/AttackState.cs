using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{

    public void OnEnter<T>(T character)
    {
        if(character is MeleeHero meleeHero)
        {
            meleeHero.ChangeStateHeroNotMoving();
            
        }
        
    }

    public void OnExecute<T>(T character)
    {
        if (character is MeleeHero meleeHero)
        {
            meleeHero.RotateTowardsTarget();
            if (!meleeHero.IsDead)
            {
                meleeHero.OnAttack();
                if(!meleeHero.IsTargetInRange())
                {
                    meleeHero.ChangeState(new MoveState());
                }
            }
            
        }
    }


    public void OnExit<T>(T character)
    {
        
    }
}
