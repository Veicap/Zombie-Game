using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void OnEnter<T>(T character);
    public void OnExecute<T>(T character);
    public void OnExit<T>(T character);
}
