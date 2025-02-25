using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartrolBossState : IBossState
{
    public void OnEnter(BossZombie bossZombie)
    {
        bossZombie.OnMove();
    }

    public void OnExecute(BossZombie bossZombie)
    {
        if (!bossZombie.IsDead())
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
            if (bossZombie.HasCharacterTarget())
            {
                bossZombie.ChangeState(new FollowBossState());
            }
            if (bossZombie.HasTargetInRange())
            {

                bossZombie.ChangeState(new AttackBossState());
            }
            /*if (normalZombie.HasTargetInRange())
            {
                normalZombie.ChangeState(new AttackZombieNormalState());
            }*/
        }
    }

    public void OnExit(BossZombie bossZombie)
    {

    }
}
