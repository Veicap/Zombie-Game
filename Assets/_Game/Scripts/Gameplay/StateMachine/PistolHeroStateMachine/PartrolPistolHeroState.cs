using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PartrolPistolHeroState : IPistolHeroState
{
    public void OnEnter(PistolHero pistolHero)
    {

    }

    public void OnExecute(PistolHero pistolHero)
    {
        if (!pistolHero.IsDead())
        {
            if (pistolHero.HasCharacterTarget())
            {
                pistolHero.ChangeState(new FollowPistolHeroState());
            }
            if (pistolHero.HasTargetInRange())
            {
                pistolHero.ChangeState(new AttackPistolHeroState());
            }

        }
    }

    public void OnExit(PistolHero pistolHero)
    {

    }
}
