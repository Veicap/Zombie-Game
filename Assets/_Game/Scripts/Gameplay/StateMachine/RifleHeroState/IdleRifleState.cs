using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class IdleRifleState : IRifleState
{
    public void OnEnter(RifleHero rifleHero)
    {
        rifleHero.ChangeToIdleState();
    }

    public void OnExecute(RifleHero rifleHero)
    {
        if (rifleHero.HasTarget())
        {
            rifleHero.ChangeState(new MoveRifleState());
        }
    }

    public void OnExit(RifleHero rifleHero)
    {

    }
}
