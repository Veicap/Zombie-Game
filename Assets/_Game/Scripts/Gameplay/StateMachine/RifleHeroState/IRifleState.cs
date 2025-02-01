using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRifleState
{
    public void OnEnter(RifleHero rifleHero);
    public void OnExecute(RifleHero rifleHero);
    public void OnExit(RifleHero rifleHero);
}
