using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    [SerializeField] private Effect hitEffect;
    private GoalTarget goalTarget;
    public GoalTarget GoalTarget => goalTarget;
    public override void OnInit()
    {
        base.OnInit();
        goalTarget = LevelManager.Ins.heroTurret;
        SimplePool.PreLoad(hitEffect, 3, LevelManager.Ins.transform);
    }
    public Effect SpawnHitEffect(Transform parent)
    {
        return SimplePool.Spawn<Effect>(hitEffect.PoolType, parent.position, parent.rotation);
    }
    

    public override void Update()
    {
        base.Update();
    }

    public override void OnAttack()
    {
        base.OnAttack();
    }

    public override void OnDeath()
    {
        base.OnDeath();
        //LevelManager.Ins.RemoveZombieDeadthFormList(this);
    }
}
