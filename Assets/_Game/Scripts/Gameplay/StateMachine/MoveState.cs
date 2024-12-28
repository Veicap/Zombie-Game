using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{

    public void OnEnter<T>(T character)
    {
        
    }

    public void OnExecute<T>(T character)
    {
        if(character is MeleeHero meleHero)
        {
            meleHero.OnMove();
            if(meleHero.InRangeAttack())
            {
                meleHero.ChangeState(new AttackState());
            }
        }
    }

    public void OnExit<T>(T character)
    {
       
    }
}
