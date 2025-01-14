using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSight : MonoBehaviour
{
    [SerializeField] Zombie zombie;
    [SerializeField] GoalTarget goalTarget;
    private readonly List<Hero> listTargetInsight = new();
    private ITarget currentTarget;

    private void Start()
    {
        zombie.SetTarget(goalTarget);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        // sight of zombie
        if (other.CompareTag("Hero"))
        {
            if (!listTargetInsight.Contains(other.GetComponent<Hero>()))
            {
                listTargetInsight.Add(other.GetComponent<Hero>());
            }
            zombie.SetTarget(listTargetInsight[0]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Hero"))
        {
            zombie.SetTarget(goalTarget);
        }
    }
}
