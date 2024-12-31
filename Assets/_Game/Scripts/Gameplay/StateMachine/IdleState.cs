using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public void OnEnter(Character character)
    {
        if (character is GunHero gunHero)
        {
            gunHero.ChangeToIdleState();
        }
    }

    public void OnExecute(Character character)
    {
        if(character is GunHero gunHero)
        {
            if(gunHero.HasTarget())
            {
                gunHero.ChangeState(new MoveState());
            }
        }

    }

    public void OnExit(Character character)
    {
        
    }
}
