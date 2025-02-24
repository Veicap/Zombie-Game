using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    [SerializeField] private Effect hitEffect;
    private GoalTarget goalTarget;
    public GoalTarget GoalTarget => goalTarget;

    /*private void Start()
    {
        OnInit(100);
    }*/
    public override void OnInit(int hpNeedToSpawn)
    {
        base.OnInit(hpNeedToSpawn);
        hp = hpNeedToSpawn;
        goalTarget = LevelManager.Ins.heroTurret;
        SimplePool.PreLoad(hitEffect, 3, LevelManager.Ins.transform);
        SetTarget(GoalTarget);
        
    }
    public Effect SpawnHitEffect(Transform parent)
    {
        return SimplePool.Spawn<Effect>(hitEffect.PoolType, parent.position, parent.rotation);
    }
    
    public override void Update()
    {
        base.Update();
        Debug.Log(HasTarget());
       // Debug.Log(CurrentState);
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
