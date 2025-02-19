using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class IdlePistolHeroState : IPistolHeroState
{
    public void OnEnter(PistolHero pistolHero)
    {
        pistolHero.ChangeToIdleState();
    }

    public void OnExecute(PistolHero pistolHero)
    {
        if (pistolHero.HasTarget())
        {
            pistolHero.ChangeState(new PartrolPistolHeroState());
        }
    }

    public void OnExit(PistolHero pistolHero)
    {

    }
}
