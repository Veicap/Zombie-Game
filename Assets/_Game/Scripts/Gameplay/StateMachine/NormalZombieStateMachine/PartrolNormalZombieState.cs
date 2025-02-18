using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PartrolNormalZombieState : IZombieNormalState
{
   /// float counter = 0;
    public void OnEnter(NormalZombie normalZombie)
    {
        // Update mot lan duy nhat neu muc tieu la co dinh
        normalZombie.OnMove();
    }

    public void OnExecute(NormalZombie normalZombie)
    {
        if(!normalZombie.IsDead())
        {
            // old
            /*// Neu co muc tieu trong tam danh
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

            }*/
            // Todo new()
            // Neu muc tieu khong co dinh => Chuyen sang follow theo muc tieu
            if (normalZombie.HasCharacterTarget())
            {
                normalZombie.ChangeState(new FollowZombieNormalState());
            }
            if (normalZombie.HasTargetInRange())
            {

                normalZombie.ChangeState(new AttackZombieNormalState());
            }
            /*if (normalZombie.HasTargetInRange())
            {
                normalZombie.ChangeState(new AttackZombieNormalState());
            }*/
        }
        
    }

    public void OnExit(NormalZombie normalZombie)
    {

    }
}
