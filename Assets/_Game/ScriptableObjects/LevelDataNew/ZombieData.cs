using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ZombieData")]
public class ZombieData : ScriptableObject
{
    [SerializeField] Zombie[] zombies;
    public Zombie GetPrefab(Scriptable.ZombieType zombie)
    {
        return zombies[(int)zombie];
    }
}