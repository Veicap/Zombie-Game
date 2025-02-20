using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LoadAttackState : IState
{
    float attackCooldown = 0;
    public void OnEnter(Character character)
    {
        character.StopMoving();
    }   

    public void OnExecute(Character character)
    {
        if(!character.IsDead())
        {
            attackCooldown += Time.deltaTime;
            if (attackCooldown >= character.AttackSpeed)
            {
                if (!character.HasTargetInRange())
                {
                    
                    character.ChangeState(new IdleState());
                }
                if (character.Target != null && !character.Target.IsDead())
                {
                    character.Target.OnHit(character.Damage);
                }
                attackCooldown = 0f;
                character.ChangeState(new AttackState());
            }
        }
    }

    public void OnExit(Character character)
    {
       
    }
}
