using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    /*private void Start()
    {
        OnInit();
    }*/
    private GoalTarget goalTarget;
    public GoalTarget GoalTarget => goalTarget;
    public override void OnInit()
    {
        base.OnInit();
        goalTarget = LevelManager.Ins.heroTurret;
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
        LevelManager.Ins.RemoveZombieDeadthFormList(this);
    }
}
