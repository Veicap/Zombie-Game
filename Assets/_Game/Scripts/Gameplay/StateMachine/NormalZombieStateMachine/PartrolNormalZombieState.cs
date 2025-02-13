using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PartrolNormalZombieState : IZombieNormalState
{
    float counter = 0;
    public void OnEnter(NormalZombie normalZombie)
    {

    }

    public void OnExecute(NormalZombie normalZombie)
    {
        if(!normalZombie.IsDead())
        {
            // old
            normalZombie.OnMove();  
            
            
            // Neu co muc tieu trong tam danh
            if (normalZombie.HasTargetInRange())
            {
                // chuyen sang trang thai tan cong
                normalZombie.ChangeState(new AttackZombieNormalState());
            }
            else
            {
                counter += Time.deltaTime;
                if (counter > 2.2f)
                {
                    counter = 0;
                    normalZombie.ChangeState(new IdleZombieNormalState());
                }

            }
            // Todo new()
            normalZombie.MoveForward();
            if (normalZombie.HasTarget())
            {
                normalZombie.ChangeState(new FollowZombieNormalState());
            }
        }
        
    }

    public void OnExit(NormalZombie normalZombie)
    {

    }
}
