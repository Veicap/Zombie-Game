using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scriptable
{
    public enum ZombieType
    {
        None = 0,
        Red = 1,
        Blue = 2,
        Green = 3,
        Orange = 4,
    }

    [CreateAssetMenu(menuName = "ColorData")]
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