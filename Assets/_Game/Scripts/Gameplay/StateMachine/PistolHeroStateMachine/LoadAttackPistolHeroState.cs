using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LoadAttackPistolHeroState : IPistolHeroState
{
    float attackCooldown = 0;
    public void OnEnter(PistolHero pistolHero)
    {
        pistolHero.StopMoving();
    }

    public void OnExecute(PistolHero pistolHero)
    {
        if (!pistolHero.IsDead())
        {
            if (!pistolHero.HasTargetInRange())
            {
                // Debug.Log("Change Move State");
                pistolHero.ChangeState(new PartrolPistolHeroState());
            }
            else
            {
                attackCooldown += Time.deltaTime;
                if (attackCooldown >= pistolHero.AttackSpeed)
                {
                    attackCooldown = 0f;
                    pistolHero.ChangeState(new AttackPistolHeroState());
                }
            }
        }
    }

    public void OnExit(PistolHero pistolHero)
    {

    }
}
