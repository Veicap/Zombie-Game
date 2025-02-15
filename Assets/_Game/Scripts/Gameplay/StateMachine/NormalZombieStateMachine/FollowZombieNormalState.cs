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
        
        if (!normalZombie.IsDead())
        {
            normalZombie.OnMove(); //MoveToTarget Update lien tuc de tien toi vi tru cua doi tuong

            // Neu khong co target hoac target chet thi chuyen sang partrol state
            if (!normalZombie.HasTarget())
            {
                normalZombie.ChangeState(new PartrolNormalZombieState());
            }
            // neu doi tuong trong tam danh thi => chuyen sang attack State
            
            if (normalZombie.HasTargetInRange())
            {

                normalZombie.ChangeState(new AttackZombieNormalState());
            }
        }
        // Todo 
       
       
    }

    public void OnExit(NormalZombie normalZombie)
    {
    
    }
}
