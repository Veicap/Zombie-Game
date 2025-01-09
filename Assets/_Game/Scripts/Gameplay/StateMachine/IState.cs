using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    // Istate using for both character and zombie
    public void OnEnter(Character character);
    public void OnExecute(Character character);
    public void OnExit(Character character);
}
