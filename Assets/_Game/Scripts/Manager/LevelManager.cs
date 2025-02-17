using Scriptable;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : Singleton<LevelManager> 
{
    [SerializeField] private Transform spawnHeroPoints;
    [SerializeField] private Transform parentPool;
    //[SerializeField] private ListLevelDataSO listLevelDataSO;
    [SerializeField] private List<Transform> spawnZombiePoints;
    [SerializeField] private ZombieData zombieDataSO;
    [SerializeField] private List<LevelData> listLevelDataSO; 


    private readonly List<Hero> listHeroesSpawned = new();
    private readonly List<Zombie> listZombieSpawned = new();

    public GoalTarget heroTurret;
    public GoalTarget zombieTurret;
    private float numberOfMana;
    private float counter;
    private const float maxMana = 100;
    int currentLevel;
   // private LevelDataSO currentLevelData;
    private LevelData currentLevelData;
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

    public void DespawnEffect(Effect effect)
    {
        StartCoroutine(IEDespawnEffect(effect));
    }

    private IEnumerator IEDespawnEffect(Effect effect)
    {
        yield return new WaitForSeconds(0.5f);
        SimplePool.Despawn(effect);
    }

    private IEnumerator SpawnRandomZombies()
    {
        while (currentWave <= currentLevelData.waveDatas.Count)
        {
            int numberOfZombiesToSpawn = 0;
            for (int i = 0; i < currentLevelData.waveDatas[currentWave-1].zombies.Count; i++)
            {
                numberOfZombiesToSpawn += currentLevelData.waveDatas[currentWave - 1].zombies[i].amount;

            }
            /* 
             for (int i = 0; i < currentLevelData.waveDatas[currentWave - 1].zombies.Count; i++)
             {
                 availableZombieTypes.Add(currentLevelData.waveDatas[currentWave - 1].zombies[i].type);
             }*/
            List<ZombieType> zombiesToSpawn = new();
            for (int i = 0; i < currentLevelData.waveDatas[currentWave - 1].zombies.Count; i++)
            {
                for(int j = 0; j < currentLevelData.waveDatas[currentWave - 1].zombies[i].amount; j++)
                {
                    zombiesToSpawn.Add(currentLevelData.waveDatas[currentWave - 1].zombies[i].type);
                }
            }
            Dictionary<ZombieType, int> dataOfZombieType = new();
            for (int i = 0; i < currentLevelData.waveDatas[currentWave - 1].zombies.Count; i++)
            {
                if (!dataOfZombieType.ContainsKey(currentLevelData.waveDatas[currentWave - 1].zombies[i].type))
                {
                    dataOfZombieType[currentLevelData.waveDatas[currentWave - 1].zombies[i].type] = (int)currentLevelData.waveDatas[currentWave - 1].zombies[i].hp;
                }
            }
            ShuffleList(zombiesToSpawn);
            for (int i = 0; i < numberOfZombiesToSpawn; i++)
            {
                SpawnZombieBasedOnWave(zombiesToSpawn[i], dataOfZombieType);
                yield return new WaitForSeconds((float)(currentLevelData.waveDatas[currentWave - 1].timeActive/numberOfZombiesToSpawn));
            }
            yield return new WaitForSeconds(8f);
            currentWave++;
        }
    }

    private void SpawnZombieBasedOnWave(ZombieType selectedZombieType, Dictionary<ZombieType, int> dataOfZombieType)
    {
        //ZombieType selectedZombieType = availableZombies[Random.Range(0, availableZombies.Count)];
        Transform spawnPoint = spawnZombiePoints[Random.Range(0, spawnZombiePoints.Count)];
        Zombie zombieSpawn = SimplePool.Spawn<Zombie>(zombieDataSO.GetPrefab(selectedZombieType).PoolType, spawnPoint.position, spawnPoint.rotation);
        zombieSpawn.OnInit(dataOfZombieType[selectedZombieType]);
        listZombieSpawned.Add(zombieSpawn);
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
        currentLevel = level;
        currentLevelData = listLevelDataSO[currentLevel - 1];

        for (int i = 0; i < currentLevelData.waveDatas.Count; i++)
        {
            for(int j = 0; j < currentLevelData.waveDatas[i].zombies.Count; j++)
            {
                SimplePool.PreLoad(zombieDataSO.GetPrefab(currentLevelData.waveDatas[i].zombies[j].type), 1, parentPool);
            }
            
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
        listHeroesSpawned.Add(hero);
        hero.OnInit(100);
    }

    public void ReduceManaOfGame(float numberOfMana)
    {
        this.numberOfMana -= numberOfMana;
    }

    public void CollectItem(AddDictionaryItem item)
    {
        //thu thap nhung thang item da hoan thanh
    }

    public void RemoveZombieDeadthFormList(Zombie zombie)
    {
        listZombieSpawned.Remove(zombie);
       // SimplePool.Despawn(zombie);
    }

    public void RemoveHeroDeadthFromList(Hero hero)
    {
        listHeroesSpawned.Remove(hero);
       // SimplePool.Despawn(hero);
    }
    public void ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = UnityEngine.Random.Range(0, i + 1);
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }

}


