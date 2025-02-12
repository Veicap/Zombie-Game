using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimplePool
{
    private static Dictionary<PoolType, Pool> poolInstance = new Dictionary<PoolType, Pool>();
    // Khoi tao pool moi 
    // Ban đầu cần khởi tạo pool cho mỗi kiểu của cái unit trong pool ta gọi là (PoolType)
    public static void PreLoad(GameUnit prefab, int amount, Transform parent)
    {
        if (prefab == null)
        {
            Debug.LogError("prefab is empty !!!");
            return;
        }
        // nếu trong dictionary chưa có kiểu pool type này hoặc kiểu pooltype này cho set pool thì cần setpoool cho nó
        // tạo pool dựa theo type của prefab
        if (!poolInstance.ContainsKey(prefab.PoolType) || poolInstance[prefab.PoolType] == null)
        {
            Pool p = new();
            p.PreLoad(prefab, amount, parent);
            poolInstance[prefab.PoolType] = p;
        }
    }
    // Lay phan ra
    public static T Spawn<T>(PoolType poolType, Vector3 Pose, Quaternion rot) where T : GameUnit
    {
        if (!poolInstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + " IS NOT PRELOAD !!!");
            return null;
        }
        return poolInstance[poolType].Spawn(Pose, rot) as T;

    }
    // tra phan tu vao
    public static void Despawn(GameUnit gameUnit)
    {
        if (!poolInstance.ContainsKey(gameUnit.PoolType))
        {
            Debug.LogError(gameUnit.PoolType + "IS NOT PRELOAD !!!");

        }
        poolInstance[gameUnit.PoolType].Despawn(gameUnit);
    }
    // thu thap tat ca dang su dung cho ve =pool
    public static void Collect(PoolType poolType)
    {
        if (!poolInstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + "IS NOT PRELOAD !!!");

        }
        poolInstance[poolType].Collect();
    }
    // thu thap tat ca
    public static void CollectAll()
    {
        foreach (var item in poolInstance.Values)
        {
            item.Collect();
        }
    }
    // Destroy pool
    public static void Release(PoolType poolType)
    {
        if (!poolInstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + "IS NOT PRELOAD !!!");

        }
        poolInstance[poolType].Release();
    }
    // Destroy tat ca
    public static void ReleaseAll()
    {
        foreach (var item in poolInstance.Values)
        {
            item.Release();
        }
    }

    /*public static void ReleaseAll<T>()
    {
        foreach (var item in poolInstance.Values)
        {
            item.Release();
        }
    }*/
}

public class Pool
{
    Transform parent;
    GameUnit prefab;

    // List chua cac unit dang o trong pool
    Queue<GameUnit> inActives = new Queue<GameUnit>();
    // List cacs unit dang duoc su dung
    List<GameUnit> actives = new List<GameUnit>();

    // Khoi tao pool
    // Khởi tạo pool cho từng Pool Type cụ thể
    // Trường hợp này xảy ra khi bắt đầu game hoặc bắt đầu màn chơi
    public void PreLoad(GameUnit prefab, int amount, Transform parent)
    {
        this.parent = parent;
        this.prefab = prefab;
        for (int i = 0; i < amount; i++)
        {
            // Tạo ra các object sau đó đưa nó vào pool 
            Despawn(Object.Instantiate(prefab, parent));
        }
    }
    // Lay phan tử từ pool
    // Những trường hợp cần lấy phần tử từ pool
    // (1) Là lúc cần sử dụng object (trong trường hợp này là khi viên đạn bắt đầu băn ra)
    // (2) Lúc bắt đầu khởi tạo pool
    public GameUnit Spawn(Vector3 pos, Quaternion rot)
    {
        GameUnit unit;
        // neu ma trong inactives ma chua co phan tu nao day thi minh phai tao ra mot thang unit tai cai simple pooling ta tạo ra trong scene
        //Debug.Log("Amount pool in inactives" + inActives.Count);
        if (inActives.Count <= 0)
        {
            unit = Object.Instantiate(prefab, parent);
        }
        else
        {
            // neu ma trong inactive ma da co roi thi ta loi thang do tu trong pool ra
            unit = inActives.Dequeue();
        }

        unit.TF.SetPositionAndRotation(pos, rot); // Set vi tri cho no tai diem cua moi khau sung
        actives.Add(unit); // add thang unit nay vao danh sach cac unit dang hoat dong de ty nua thu hoi no ve
        unit.gameObject.SetActive(true); // set active cho thang unit
        return unit;

    }

    // Despawn o day ko phai huy ma la dua object quay tro ve pool thoi
    // Truong hop phai quay tro ve pool bao gom: 
    // (1) sau khi object không còn sử dụng mà vẫn muốn tái sử dụng ta cho vào lại pool
    // (2) bat dau preload se phai đưa các object quay trở lại pool                                          
    public void Despawn(GameUnit unit)
    {
        // kiem tra xem co dang active hay khong
        if (unit != null  && unit.gameObject.activeSelf)
        {
           // Debug.Log("Despawn");
            inActives.Enqueue(unit);
            actives.Remove(unit);
            unit.gameObject.SetActive(false);
        }
    }
    // Thu thap tat ca phan tu dang dung ve pool
    public void Collect()
    {
        while (actives.Count > 0)
        {
            Despawn(actives[0]);
        }
    }
    // Destroy tat ca phan tu
    public void Release()
    {
        Collect();
        while (inActives.Count > 0)
        {
            GameObject.Destroy(inActives.Dequeue().gameObject);
        }
        inActives.Clear();
    }
}
