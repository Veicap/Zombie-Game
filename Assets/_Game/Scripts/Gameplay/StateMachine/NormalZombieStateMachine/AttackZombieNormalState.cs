using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackZombieNormalState : IZombieNormalState
{
    public void OnEnter(NormalZombie normalZombie)
    {
        normalZombie.StopMoving();
    }

    public void OnExecute(NormalZombie normalZombie)
    {
        if (!normalZombie.IsDead() && normalZombie.RotateTowardsTarget())
        {
            
            if (!normalZombie.HasTarget())
            {
                normalZombie.ChangeState(new PartrolNormalZombieState());
            }
            else
            {
                // Neu ke dich khong o trong tam danh
                if (!normalZombie.HasTargetInRange())
                {
                    normalZombie.ChangeState(new PartrolState());
                }
                else // Neu Ke dich trong tam danh
                {
                    normalZombie.OnAttack();
                    var target = normalZombie.Target;
                    normalZombie.ChangeState(new LoadAttackNormalZombieState(target));
                }
            }
            // Neu khong co muc tieu
        }
    }

    public void OnExit(NormalZombie normalZombie)
    {
        
    }
}
