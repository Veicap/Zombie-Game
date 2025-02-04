using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSight : MonoBehaviour
{
    [SerializeField] private Zombie zombie;
    [SerializeField] private GoalTarget goalTarget;
    private readonly List<Hero> listHeroInsight = new();
    private Hero currentHeroTarget;

    private void Start()
    {
        zombie.SetTarget(zombie.GoalTarget);
    }

    private void Update()
    {
        if (currentHeroTarget != null && currentHeroTarget.IsDead())
        {
            listHeroInsight.Remove(currentHeroTarget);
            UpdateCurrentTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            Hero hero = other.GetComponent<Hero>();
            if (hero != null && !listHeroInsight.Contains(hero))
            {
                listHeroInsight.Add(hero);
                if (currentHeroTarget == null)
                {
                    UpdateCurrentTarget();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            Hero hero = other.GetComponent<Hero>();
            if (hero != null && listHeroInsight.Contains(hero))
            {
                listHeroInsight.Remove(hero);
                if (currentHeroTarget == hero)
                {
                    UpdateCurrentTarget();
                }
            }
        }
    }

    private void UpdateCurrentTarget()
    {
        if (listHeroInsight.Count > 0)
        {
            currentHeroTarget = listHeroInsight[0];
            zombie.SetTarget(currentHeroTarget);
        }
        else
        {
            currentHeroTarget = null;
            zombie.SetTarget(zombie.GoalTarget);
        }
    }
}
