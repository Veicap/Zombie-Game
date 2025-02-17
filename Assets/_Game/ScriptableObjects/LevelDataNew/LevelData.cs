using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scriptable
{
    public enum ZombieType
    {
        Normal_Zombie = 0,
        Fast_Zombie = 1,
        Boss_Zombie = 2,
    }

    [CreateAssetMenu(menuName = "ZombieData")]
    public class LevelData : ScriptableObject
    {
        public List<WaveData> waveDatas;

        [System.Serializable]
        public class ZombieData
        { 
            public ZombieType type;
            public int amount;
            public float hp;
        }

        [System.Serializable]
        public class WaveData
        {
            public float timeActive = 5f;
            public List<ZombieData> zombies;
        }
    }
}