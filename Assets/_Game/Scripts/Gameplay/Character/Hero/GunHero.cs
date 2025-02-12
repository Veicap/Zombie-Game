using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHero : Hero
{
    [SerializeField] protected Gun gun;
    public override void Update()
    {
        base.Update();  
    }

    public override void OnInit()
    {
        base.OnInit();
        gun.PreLoadBullet();
    }

    public override void OnAttack()
    {
       // base.OnAttack();
       
        attackCooldown += Time.deltaTime;
        if (attackCooldown >= AttackSpeed)
        {
            gun.SpawnBullet(TargetTransform);
            isAttacking = true;
            attackCooldown = 0f;
            ChangeAnimation(Constants.ANIM_ATTACK);
        }

    }
}
