using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroSight : MonoBehaviour
{
    [SerializeField] Hero hero;
    [SerializeField] GoalTarget goalTarget;
    private readonly List<Zombie> listZombieInsight = new();
    private Zombie currentZombieTarget;

    private void Start()
    {
        if (hero is GunHero)
        {
            hero.SetTarget(null);
        }
        else if( hero is MeleeHero)
        {
            hero.SetTarget(goalTarget);
        }
    }

    private void Update()
    {
        if (currentZombieTarget != null && currentZombieTarget.IsDead())
        {
            listZombieInsight.RemoveAt(0);
            if(listZombieInsight.Count > 0)
            {
                currentZombieTarget = listZombieInsight[0];
                hero.SetTarget(currentZombieTarget);
            }
            else
            {
                if(hero is GunHero)
                {
                    hero.SetTarget(null);
                }
                else if (hero is MeleeHero) {
                    hero.SetTarget(goalTarget);
                }
                currentZombieTarget = null;
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

       
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Zombie"))
        {
            if(!listZombieInsight.Contains(other.GetComponent<Zombie>()))
            {
                listZombieInsight.Add(other.GetComponent<Zombie>());
            }
            currentZombieTarget = listZombieInsight[0];
            hero.SetTarget(currentZombieTarget);
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
