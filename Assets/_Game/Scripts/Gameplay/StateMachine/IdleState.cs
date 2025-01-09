using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public void OnEnter(Character character)
    {
        character.ChangeToIdleState();
    }

    public void OnExecute(Character character)
    {
        if (character.HasTarget())
        {
            character.ChangeState(new MoveState());
        }
    }

    public void OnExit(Character character)
    {
        
    }
}
