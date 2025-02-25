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
    Zombie_Regular = 5,
    Zombie_Fast = 6,
    Zombie_Boss= 7,
    
    // HealBar_Zombie
    HealBar_Zombie = 8, 
    
    // Bullet
    Bullet_Green = 9,
    Bullet_Red = 10,
    Bullet_Blue = 11,

    // Hit effect
    HitEffect_Zombie = 12,

    // HealBar_Hero
    HealBar_Hero = 13,

    // Combat Text
    Combat_Text = 14,
    
    // Hit Effect
    HitEffect_Boss_To_Hero = 15,
}
