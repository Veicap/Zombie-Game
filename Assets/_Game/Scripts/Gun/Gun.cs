using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform pointToSpawnBullet;
    [SerializeField] private Bullet bulletToShoot;

    private List<Bullet> listBulletSpawned = new();

    public void PreLoadBullet()
    {
        SimplePool.PreLoad(bulletToShoot, 3, transform);
    }


    public void SpawnBullet()
    {
        Bullet bullet = SimplePool.Spawn<Bullet>(bulletToShoot.PoolType, pointToSpawnBullet.position, pointToSpawnBullet.rotation);
        bullet.MoveForward(pointToSpawnBullet);
        if(!listBulletSpawned.Contains(bullet))
        {
            listBulletSpawned.Add(bullet);
        }
    }


}
