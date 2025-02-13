using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowZombieNormalState : IZombieNormalState
{
    public void OnEnter(NormalZombie normalZombie)
    {
       
    }

    public void OnExecute(NormalZombie normalZombie)
    {
        // Todo 
        normalZombie.OnMove(); //MoveToTarget
        if(!normalZombie.HasTarget())
        {
            normalZombie.ChangeState(new PartrolNormalZombieState());
        }
        if(normalZombie.HasTargetInRange())
        {
            normalZombie.ChangeState(new AttackZombieNormalState());
        }
       
    }

    public void OnExit(NormalZombie normalZombie)
    {
    
    }
}
