using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    public PoolType PoolType;
    private Transform tf;
    public Transform TF
    {
        get
        {
            if (tf == null)
            {
                tf = transform;
            }
            return tf;
        }
    }
}

public enum PoolType
{
    // Hero
    Hero_1 = 0,
    Hero_2 = 1,
    Hero_3 = 2,
    Hero_4 = 3,
    Hero_5 = 4,

    //Zombie
    Zombie_1 = 5,
    Zombie_2 = 6,   
}
