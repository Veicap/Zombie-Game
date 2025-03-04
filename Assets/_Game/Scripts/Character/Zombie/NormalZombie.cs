using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombie : Zombie
{
    private IZombieNormalState currentState;
    private void Start()
    {
        OnInit(100);
    }
    public override void Update()
    {
        currentState.OnExecute(this);
    }
    public override void OnInit(int hpNeedToSpawn)
    {
        base.OnInit(hpNeedToSpawn);
        currentState = new IdleZombieNormalState();   
    }
    public void ChangeState(IZombieNormalState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState?.OnEnter(this);
    }
    
}
