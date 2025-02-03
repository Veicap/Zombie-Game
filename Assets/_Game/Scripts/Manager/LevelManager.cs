using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : Singleton<LevelManager> 
{
    [SerializeField] private Transform spawnHeroPoint;
    private float numberOfMana;
    private float counter;
    private const float maxMana = 100;
    int level;

    public float NumberOfMana => numberOfMana;
    public float MaxMana => maxMana;
    private void Start()
    {
        OnInit();
    }
    private void Update()
    {
        counter += Time.deltaTime;
        if(counter > 1f && numberOfMana < maxMana)
        {
            numberOfMana += 1;
            counter = 0f;
        }
    }
    public void OnInit()
    {
       
        numberOfMana = 100;
        //khoi tao cac thong so truoc khi bat dau man choi
    }

    public void OnPlay()
    {
        //bat dau man choi
    }

    public void LoadLevel(int level)
    {
        //load lai object trong man choi
    }

    public void OnWin()
    {
        //thang
    }

    public void OnLose()
    {
        //thua
    }

    public void OnNextLevel()
    {
        //next 1 level
        OnDespawn();
        LoadLevel(++level);
        OnInit();
    }

    public void OnRetryLevel()
    {
        //choi lai level
        OnDespawn();
        LoadLevel(level);
        OnInit();
    }

    public void OnDespawn()
    {
        //reset tat ca cac thong so cua man choi
    }

    public void OnSpawnHero(PoolType poolType)
    {
        Character hero = SimplePool.Spawn<Character>(poolType, spawnHeroPoint.position, spawnHeroPoint.rotation);
    }

    public void ReduceManaOfGame(float numberOfMana)
    {
        this.numberOfMana -= numberOfMana;
    }

    public void CollectItem(AddDictionaryItem item)
    {
        //thu thap nhung thang item da hoan thanh
    }

}
