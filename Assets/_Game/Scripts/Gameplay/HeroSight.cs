using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroSight : MonoBehaviour
{
    [SerializeField] Hero hero;
    [SerializeField] GoalTarget goalTarget;
    private readonly List<Zombie> listZombieInsight = new();
    private ITarget currentTarget;

    private void Start()
    {
        if (hero is PistolHero)
        {
            hero.SetTarget(null);
        }
        else
        {
            hero.SetTarget(goalTarget);
        }
    }

    private void Update()
    {
        if(listZombieInsight.Count >= 2)
        {
            if(currentTarget.IsDead())
            {
                listZombieInsight.RemoveAt(0);
                hero.SetTarget(listZombieInsight[0]);
            }
        }
        /*else
        {
            if (currentTarget.IsDead())
            {
                listZombieInsight.RemoveAt(0);
                if(hero is MeleeHero)
                {
                    hero.SetTarget(goalTarget);
                }
                else if(hero is PistolHero)
                {
                    hero.SetTarget(null);
                }
            }
        }*/

        Debug.Log(listZombieInsight.Count);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            if(!listZombieInsight.Contains(other.GetComponent<Zombie>()))
            {
                listZombieInsight.Add(other.GetComponent<Zombie>());
            }
            currentTarget = listZombieInsight[0];
            hero.SetTarget(currentTarget);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            listZombieInsight.Remove(other.GetComponent<Zombie>()); 
        }
    }
}
