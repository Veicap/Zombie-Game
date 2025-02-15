using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ZombieData")]
public class ZombieData : ScriptableObject
{
    //theo tha material theo dung thu tu ColorType
    [SerializeField] Zombie[] zombies;

    //lay material theo mau tuong ung
    public Zombie GetMat(Scriptable.ZombieType zombie)
    {
        return zombies[(int)zombie];
    }
}