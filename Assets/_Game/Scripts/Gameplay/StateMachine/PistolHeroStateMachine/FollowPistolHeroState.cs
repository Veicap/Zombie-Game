using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FollowPistolHeroState : IPistolHeroState
{
    public void OnEnter(PistolHero pistolHero)
    {

    }

    public void OnExecute(PistolHero pistolHero)
    {
        if (!pistolHero.IsDead())
        {
            pistolHero.OnMove(); //MoveToTarget Update lien tuc de tien toi vi tru cua doi tuong

            // Neu khong co target hoac target chet thi chuyen sang partrol state
            if (!pistolHero.HasTarget())
            {
                pistolHero.ChangeState(new PartrolPistolHeroState());
            }
            //Debug.Log(character.HasTargetInRange());
            // neu doi tuong trong tam danh thi => chuyen sang attack State
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
