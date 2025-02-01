using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MoveRifleState : IRifleState
{
    public void OnEnter(RifleHero rifleHero)
    {

    }

    public void OnExecute(RifleHero rifleHero)
    {
        rifleHero.OnMove();
        // Neu co muc tieu trong tam danh
        if (rifleHero.IsTargetInRange())
        {
            // chuyen sang trang thai tan cong
            rifleHero.ChangeState(new AttackRifleState());
        }
    }

    public void OnExit(RifleHero rifleHero)
    {

    }
}
