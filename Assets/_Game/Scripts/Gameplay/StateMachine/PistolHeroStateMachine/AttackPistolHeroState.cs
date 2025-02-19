using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackPistolHeroState : IPistolHeroState
{
    public void OnEnter(PistolHero pistolHero)
    {
        pistolHero.StopMoving();
    }

    public void OnExecute(PistolHero pistolHero)
    {
        if (!pistolHero.IsDead() && pistolHero.RotateTowardsTarget())
        {
            // Tan cong
            // Danh cho ban xa

            if (!pistolHero.HasTarget())
            {
                pistolHero.ChangeState(new IdlePistolHeroState());
            }
            else // danh' cho danh gan (neu phat hien co ke dich)
            {
                // Xet xem ke dich co dang trong tam danh khong?
                //
                //Neu ke dich khong trong tam danh => Move
                if (!pistolHero.HasTargetInRange())
                {
                    pistolHero.ChangeState(new PartrolPistolHeroState());
                }
                else // Neu Ke dich trong tam danh
                {
                    pistolHero.OnAttack();
                    pistolHero.ChangeState(new LoadAttackPistolHeroState());
                }

            }
        }
    }

    public void OnExit(PistolHero pistolHero)
    {
       
    }
}
