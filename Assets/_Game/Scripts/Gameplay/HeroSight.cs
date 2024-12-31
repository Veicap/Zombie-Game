using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSight : MonoBehaviour
{
    [SerializeField] Character hero;
    [SerializeField] Transform barrierPoint;

    private void Awake()
    {
        if(hero is MeleeHero)
        {
            hero.SetTargetPos(barrierPoint);
        }
        if(hero is GunHero)
        {
            hero.SetTargetPos(null);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            hero.SetTargetPos(other.GetComponent<Zombie>().transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            if (hero is MeleeHero)
            {
                hero.SetTargetPos(barrierPoint.transform);
            }
            if (hero is GunHero)
            {
               // hero.SetTargetPos(null);
            }
        }
        Debug.LogError("Exit");
    }
}
