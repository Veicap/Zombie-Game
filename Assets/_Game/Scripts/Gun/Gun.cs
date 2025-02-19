using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform pointToSpawnBullet;
    [SerializeField] private Bullet bulletToShoot;
    [SerializeField] private GunHero gunHero;

    private List<Bullet> listBulletSpawned = new();

    public void PreLoadBullet()
    {
        SimplePool.PreLoad(bulletToShoot, 3, LevelManager.Ins.transform);
    }

    public void SpawnBullet(Transform TargetTransform)
    {
        Bullet bullet = SimplePool.Spawn<Bullet>(bulletToShoot.PoolType, pointToSpawnBullet.position, pointToSpawnBullet.rotation);
        bullet.MoveForward(TargetTransform);

        if(!listBulletSpawned.Contains(bullet))
        {
            listBulletSpawned.Add(bullet);
        }
    }

    public float GetHeroDamage()
    {
       return gunHero.Damage;
    }
}
