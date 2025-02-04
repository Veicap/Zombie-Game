using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroSight : MonoBehaviour
{
    [SerializeField] private Hero hero;
    private readonly List<Zombie> listZombieInsight = new();
    private Zombie currentZombieTarget;

    private void Start()
    {
        if (hero is GunHero)
        {
            hero.SetTarget(null);
        }
        else if (hero is MeleeHero)
        {
            hero.SetTarget(hero.GoalTarget);
        }
    }

    private void Update()
    {
        if (currentZombieTarget != null && currentZombieTarget.IsDead())
        {
            listZombieInsight.Remove(currentZombieTarget);
            UpdateCurrentTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Zombie zombie = other.GetComponent<Zombie>();
            if (zombie != null && !listZombieInsight.Contains(zombie))
            {
                listZombieInsight.Add(zombie);
                if (currentZombieTarget == null)
                {
                    UpdateCurrentTarget();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Zombie zombie = other.GetComponent<Zombie>();
            if (zombie != null && listZombieInsight.Contains(zombie))
            {
                listZombieInsight.Remove(zombie);
                if (currentZombieTarget == zombie)
                {
                    UpdateCurrentTarget();
                }
            }
        }
    }

    private void UpdateCurrentTarget()
    {
        if (listZombieInsight.Count > 0)
        {
            currentZombieTarget = listZombieInsight[0];
            hero.SetTarget(currentZombieTarget);
        }
        else
        {
            currentZombieTarget = null;
            if (hero is GunHero)
            {
                hero.SetTarget(null);
            }
            else if (hero is MeleeHero)
            {
                hero.SetTarget(hero.GoalTarget);
            }
        }
    }
}
