using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{

    public void OnEnter(Character character)
    {
        
    }

    public void OnExecute(Character character)
    {
        // Di chuyen
        character.OnMove();
        // Neu co muc tieu trong tam danh
        if(character.IsTargetInRange())
        {
            // chuyen sang trang thai tan cong
            character.ChangeState(new AttackState());
        }
    }

    public void OnExit(Character character)
    {
       
    }
}
