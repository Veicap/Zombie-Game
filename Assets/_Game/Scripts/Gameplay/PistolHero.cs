using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolHero : Character
{
    public override void Update()
    {
        base.Update();
        /* Debug.Log(CurrentState);
         Debug.Log("IN Range? " + IsTargetInRange());
         Debug.Log("Is moving? " + IsMoving());*/
        Debug.Log(HasTarget());
    }
    public override void OnInit()
    {
        base.OnInit();
    }

    public override void OnAttack()
    {
        // Attack
        base.OnAttack();
    }
}
