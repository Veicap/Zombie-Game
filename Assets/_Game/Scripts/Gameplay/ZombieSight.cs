using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSight : MonoBehaviour
{
    [SerializeField] Zombie zombie;
    [SerializeField] GoalTarget goalTarget;
    private readonly List<Hero> listHeroInsight = new();
    private Hero currentHeroTarget;

    private void Start()
    {
        zombie.SetTarget(goalTarget);
    }

    private void Update()
    {
        if (currentHeroTarget != null && currentHeroTarget.IsDead())
        {
            listHeroInsight.RemoveAt(0);
            if (listHeroInsight.Count > 0)
            {
                zombie.SetTarget(listHeroInsight[0]);
                currentHeroTarget = listHeroInsight[0];
            }
            else
            {
                zombie.SetTarget(goalTarget);
                currentHeroTarget = null;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        // sight of zombie  
        if (other.CompareTag("Hero"))
        {
            if (!listHeroInsight.Contains(other.GetComponent<Hero>()))
            {
                listHeroInsight.Add(other.GetComponent<Hero>());
            }
            zombie.SetTarget(listHeroInsight[0]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Hero"))
        {
            listHeroInsight.Remove(other.GetComponent<Hero>());
        }
    }
}
