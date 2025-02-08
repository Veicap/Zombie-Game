using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : Singleton<LevelManager> 
{
    [SerializeField] private Transform spawnHeroPoints;
    [SerializeField] private Transform parentPool;
    [SerializeField] private ListLevelDataSO listLevelDataSO;
    [SerializeField] private List<Transform> spawnZombiePoints;
    
    public GoalTarget heroTurret;
    public GoalTarget zombieTurret;
    private float numberOfMana;
    private float counter;
    private const float maxMana = 100;
    int currentLevel;
    private LevelDataSO currentLevelData;
    private int currentWave;
    private Coroutine c;
    public float NumberOfMana => numberOfMana;
    public float MaxMana => maxMana;
    private void Start()
    {
        UIManager.Ins.OpenUI<CanvasMainMenu>();
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
        currentWave = 1;
        c = StartCoroutine(SpawnRandomZombies());
        heroTurret.OnInit();
        zombieTurret.OnInit();  
    }

    private IEnumerator SpawnRandomZombies()
    {
        while (currentWave <= currentLevelData.maxWaves)
        {
            int zombiesToSpawn = 2 + currentWave * 2; 

            for (int i = 0; i < zombiesToSpawn; i++)
            {
               // Debug.LogError("Start");
                SpawnZombieBasedOnWave(currentWave);
                yield return new WaitForSeconds(Random.Range(3f, 4f));
            }
            yield return new WaitForSeconds(8f); 
            currentWave++;
        }
    }

    private void SpawnZombieBasedOnWave(int waveNumber)
    {
       
        List<ZombieType> availableZombies = new List<ZombieType>();
        foreach (var zombie in currentLevelData.zombieTypes)
        {
            //Debug.LogError("Begin");
            if (zombie.difficultyLevel <= waveNumber)
            {
                //Debug.Log("Continue");
                for (int i = 0; i < zombie.difficultyLevel; i++)
                {
                    availableZombies.Add(zombie);
                }
            }
        }

        if (availableZombies.Count == 0)
        {
            return;
        }
        ZombieType selectedZombie = availableZombies[Random.Range(0, availableZombies.Count)];
      
       // Debug.Log(availableZombies.Count);
        Transform spawnPoint = spawnZombiePoints[Random.Range(0, spawnZombiePoints.Count)];
        Zombie zombieSpawn = SimplePool.Spawn<Zombie>(selectedZombie.prefab.PoolType, spawnPoint.position, spawnPoint.rotation);
        zombieSpawn.OnInit();
    }

    public void OnPlay()
    {
        //bat dau man choi
    }

    public void LoadLevel(int level)
    {
        if(c != null) StopCoroutine(c);
        SimplePool.ReleaseAll();
        CanvasGamePlay.Instance.OnInit();
        //load lai object trong man choi
        currentLevel = level;
        currentLevelData = listLevelDataSO.listLevelDataSO[currentLevel - 1];
        for (int i = 0; i < currentLevelData.zombieTypes.Count; i++)
        {
            SimplePool.PreLoad(currentLevelData.zombieTypes[i].prefab, 1, parentPool);
        }
        OnInit();
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
        LoadLevel(++currentLevel);
        
    }

    public void OnRetryLevel()
    {
        //choi lai level
        OnDespawn();
        // Preload lai element cua level
        PoolControll.Ins.PreloadInit();
        // Load lai doc lai data
        LoadLevel(currentLevel);
        //Khoi tao level
        
    
    }

    public void OnDespawn()
    {
        //reset tat ca cac thong so cua man choi
        //SimplePool.ReleaseAll();
    }

    public void OnSpawnHero(PoolType poolType)
    {
        Hero hero = SimplePool.Spawn<Hero>(poolType, spawnHeroPoints.position, spawnHeroPoints.rotation);
        hero.OnInit();
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
