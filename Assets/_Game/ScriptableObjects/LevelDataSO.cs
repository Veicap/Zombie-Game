using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LevelDataSO : ScriptableObject
{
    public List<ZombieType> zombieTypes = new();
    public int level;
    public int maxWaves;
}

[System.Serializable]
public class ZombieType
{
    public string type;
    public Zombie prefab;
    public int difficultyLevel;
}
