using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHero : Hero
{
    public override void Update()
    {
        base.Update();
        //Debug.Log(HasTarget());
        Debug.Log(offsetRange);
    }
    public override void OnInit()
    {
        base.OnInit();
    }
    public override void OnAttack()
    {
        base.OnAttack();
    }
}
