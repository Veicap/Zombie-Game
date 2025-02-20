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
            var target = character.Target;
            attackCooldown += Time.deltaTime;
            if (attackCooldown >= character.AttackSpeed)
            {
                if (!character.HasTargetInRange())
                {
                    
                    character.ChangeState(new IdleState());
                }
                if (target != null && !target.IsDead())
                {
                    target.OnHit(character.Damage);
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
