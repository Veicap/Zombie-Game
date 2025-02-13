using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombie : Zombie
{
    private IZombieNormalState currentState;

    /*public void Start()
    {
        OnInit();
    }*/
    public override void Update()
    {
       // Debug.Log(currentState.ToString());
       // Debug.Log(isMoving);
        currentState.OnExecute(this);
        
        //Debug.Log(CurrentState.ToString());
    }
    public override void OnInit()
    {
        base.OnInit();
        currentState = new IdleZombieNormalState();
        isMoving = false;    
    }
    public void ChangeState(IZombieNormalState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState?.OnEnter(this);
    }
    //Todo
    public void MoveForward()
    {

    }
}
