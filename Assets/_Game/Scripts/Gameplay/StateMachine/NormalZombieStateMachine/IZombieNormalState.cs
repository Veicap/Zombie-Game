using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZombieNormalState
{
    public void OnEnter(NormalZombie normalZombie);
    public void OnExecute(NormalZombie normalZombie);
    public void OnExit(NormalZombie normalZombie);
}
