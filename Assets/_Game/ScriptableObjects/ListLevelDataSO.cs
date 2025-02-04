using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ListLevelDataSO : ScriptableObject
{
    public List<LevelDataSO> listLevelDataSO = new();
    public int level;
}
