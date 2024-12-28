using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{

    public void OnEnter<T>(T character)
    {
        if (character is MeleeHero meleeHero)
        {
            meleeHero.SetIsMove(false);
        }
    }

    public void OnExecute<T>(T character)
    {
        if (character is MeleeHero meleeHero)
        {
            if(!meleeHero.IsDead)
            {
                meleeHero.OnAttack();
                if(!meleeHero.InRangeAttack())
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
