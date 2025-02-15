using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHero : Hero
{
    [SerializeField] protected Gun gun;
    public override void Update()
    {
        base.Update();
        Debug.Log(CurrentState.ToString());
        //Debug.Log(HasTargetInRange());
    }
  
    public override void OnInit()
    {
        base.OnInit();
        gun.PreLoadBullet();
       
    }

    public override void OnAttack()
    {
        gun.SpawnBullet(TargetTransform);
        ChangeAnimation(Constants.ANIM_ATTACK);
    }
}
