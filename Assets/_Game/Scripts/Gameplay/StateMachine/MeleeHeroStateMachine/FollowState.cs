using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : IState
{
    public void OnEnter(Character character)
    {
       
    }

    public void OnExecute(Character character)
    {
       
       // Debug.Log(character.HasTargetInRange());
        if (!character.IsDead())
        {
            character.OnMove(); //MoveToTarget Update lien tuc de tien toi vi tru cua doi tuong

            // Neu khong co target hoac target chet thi chuyen sang partrol state
            if (!character.HasTarget())
            {
                character.ChangeState(new PartrolState());
            }
            //Debug.Log(character.HasTargetInRange());
            // neu doi tuong trong tam danh thi => chuyen sang attack State
            if (character.HasTargetInRange())   
            {
               
                character.ChangeState(new AttackState());
            }
        }
        
    }

    public void OnExit(Character character)
    {
       
    }

}
