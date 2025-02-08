using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    [Header("Hero Attributes")]
    [SerializeField] private int manaToSpawn;
    [SerializeField] private float timeToSpawn;
    private GoalTarget goalTarget;
    public GoalTarget GoalTarget => goalTarget;
    public override void OnInit()
    {
        base.OnInit();
        goalTarget = LevelManager.Ins.zombieTurret;
    }

    public int ManaToSpawn => manaToSpawn;
    public float TimeToSpawn => timeToSpawn;

    public override void OnDeath()
    {
        base.OnDeath();
        LevelManager.Ins.RemoveHeroDeadthFromList(this);
    }
}
