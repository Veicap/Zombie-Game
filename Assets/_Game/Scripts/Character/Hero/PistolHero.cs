using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolHero : GunHero
{
    private IPistolHeroState currentState;
    /*public override void OnInit()
    {
        base.OnInit();
    }*/
    private void Start()
    {
        OnInit(100);
    }

    public void ChangeState(IPistolHeroState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState?.OnEnter(this);
    }
    public override void Update()
    {
        currentState.OnExecute(this);
    }
    public override void OnInit(int hpNeedToSpawn)
    {
        base.OnInit(hpNeedToSpawn);
        currentState = new IdlePistolHeroState();
    }
}
