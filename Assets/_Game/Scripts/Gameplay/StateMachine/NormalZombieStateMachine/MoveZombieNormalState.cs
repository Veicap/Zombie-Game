using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MoveZombieNormalState : IZombieNormalState
{
    float counter = 0;
    public void OnEnter(NormalZombie normalZombie)
    {

    }

    public void OnExecute(NormalZombie normalZombie)
    {
        if(!normalZombie.IsDead())
        {
            normalZombie.OnMove();
            // Neu co muc tieu trong tam danh
            if (normalZombie.IsTargetInRange())
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
        }
        
    }

    public void OnExit(NormalZombie normalZombie)
    {

    }
}
