using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    [Header("Character Attributes")]
    [SerializeField] private int manaToSpawn;
    [SerializeField] private float timeToSpawn;

    public int ManaToSpawn => manaToSpawn;
    public float TimeToSpawn => timeToSpawn;
}
