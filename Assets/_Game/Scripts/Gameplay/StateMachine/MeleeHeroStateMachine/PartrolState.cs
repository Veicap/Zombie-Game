using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartrolState : IState
{
    public void OnEnter(Character character)
    {
        character.OnMove();
    }

    public void OnExecute(Character character)
    {
        if (!character.IsDead())
        {
            if (character.HasCharacterTarget())
            {
                character.ChangeState(new FollowState());
            }

        }

    }

    public void OnExit(Character character)
    {
       
    }
}
