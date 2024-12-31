using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHero : Character
{
    private const string IDLE = "Idle";

    public override void Update()
    {
        base.Update();
       /* Debug.Log(CurrentState);
        Debug.Log("IN Range? " + IsTargetInRange());
        Debug.Log("Is moving? " + IsMoving());*/
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
    
    public void ChangeToIdleState()
    {
        // Chuyen sang trang thai ilde
        ChangeAnimation(IDLE);
    }

    public bool HasTarget()
    {
        return TargetTransform;
    }

}
