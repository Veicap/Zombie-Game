using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBossState
{
    public void OnEnter(BossZombie bossZombie);
    public void OnExecute(BossZombie bossZombie);
    public void OnExit(BossZombie bossZombie);
}
