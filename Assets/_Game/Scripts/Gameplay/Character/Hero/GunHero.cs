using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHero : Hero
{
    [SerializeField] private Gun gun;
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
            gun.SpawnBullet();
            isAttacking = true;
            attackCooldown = 0f;
            ChangeAnimation(Constants.ANIM_ATTACK);
        }

    }
}
