using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPistolHeroState
{
    public void OnEnter(PistolHero pistolHero);
    public void OnExecute(PistolHero pistolHero);
    public void OnExit(PistolHero pistolHero);
}
