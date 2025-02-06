using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolControll : Singleton<PoolControll>
{
    [SerializeField] PoolAmount[] poolAmounts;
    private void Awake()
    {
        PreloadInit();
    }

    public void PreloadInit()
    {
        for (int i = 0; i < poolAmounts.Length; i++)
        {
            SimplePool.PreLoad(poolAmounts[i].prefab, poolAmounts[i].amount, poolAmounts[i].parent);
        }
    }

}

[System.Serializable]
public class PoolAmount
{
    public GameUnit prefab;
    public Transform parent;
    public int amount;
}
