using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class IdleZombieNormalState : IZombieNormalState
{
    float counter = 0;
    public void OnEnter(NormalZombie normalZombie)
    {
        normalZombie.StopMoving();
        normalZombie.ChangeToIdleState();
    }

    public void OnExecute(NormalZombie normalZombie)
    {   
        counter += Time.deltaTime;
        if(!normalZombie.IsDead() && counter > Random.Range(2.8f, 3.5f))
        {
            Debug.Log("Change state move");
            counter = 0;
            normalZombie.ChangeState(new PartrolNormalZombieState());
        }
    }

    public void OnExit(NormalZombie normalZombie)
    {

    }
}

