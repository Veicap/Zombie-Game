using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : Singleton<LevelManager> 
{
    [SerializeField] private Transform spawnHeroPoint;
    [SerializeField] private Transform parentPool;
    [SerializeField] private ListLevelDataSO listLevelDataSO;
    [SerializeField] private List<Transform> spawnPoints;
    public GoalTarget heroTurret;
    public GoalTarget zombieTurret;

    private float numberOfMana;
    private float counter;
    private const float maxMana = 100;
    int currentLevel;
    private LevelDataSO currentLevelData;
    private int currentWave;

    public float NumberOfMana => numberOfMana;
    public float MaxMana => maxMana;
    private void Start()
    {
        currentLevel = 1;
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
        currentLevelData = listLevelDataSO.listLevelDataSO[currentLevel-1];
        for (int i = 0; i < currentLevelData.zombieTypes.Count; i++)
        {
            SimplePool.PreLoad(currentLevelData.zombieTypes[i].prefab, 1, parentPool);
         
        }
        currentWave = 1;
        StartCoroutine(SpawnRandomZombies());
      
    }

    IEnumerator SpawnRandomZombies()
    {
       
        while (currentWave <= currentLevelData.maxWaves)
        {
          
            int zombiesToSpawn = 5 + currentWave * 2; 

            for (int i = 0; i < zombiesToSpawn; i++)
            {
               // Debug.LogError("Start");
                SpawnZombieBasedOnWave(currentWave);
                yield return new WaitForSeconds(Random.Range(3f, 4f));
            }

            
            yield return new WaitForSeconds(8f); // Nghỉ giữa các wave
            currentWave++;
        }

        
    }

    void SpawnZombieBasedOnWave(int waveNumber)
    {
        // Tăng tỷ lệ spawn zombie mạnh hơn theo wave
        List<ZombieType> availableZombies = new List<ZombieType>();
        foreach (var zombie in currentLevelData.zombieTypes)
        {
            //Debug.LogError("Begin");
            if (zombie.difficultyLevel <= waveNumber)
            {
                //Debug.Log("Continue");
                // Tăng cơ hội xuất hiện cho zombie mạnh hơn ở wave cao hơn
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
      
        Debug.Log(availableZombies.Count);
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Character zombieSpawn = SimplePool.Spawn<Character>(selectedZombie.prefab.PoolType, spawnPoint.position, spawnPoint.rotation);
        zombieSpawn.OnInit();
        Debug.Log($"Spawned {selectedZombie.type} at {spawnPoint.position}");
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
        LoadLevel(++currentLevel);
        OnInit();
    }

    public void OnRetryLevel()
    {
        //choi lai level
        OnDespawn();
        LoadLevel(currentLevel);
        OnInit();
    }

    public void OnDespawn()
    {
        //reset tat ca cac thong so cua man choi
    }

    public void OnSpawnHero(PoolType poolType)
    {
        Character hero = SimplePool.Spawn<Character>(poolType, spawnHeroPoint.position, spawnHeroPoint.rotation);
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
