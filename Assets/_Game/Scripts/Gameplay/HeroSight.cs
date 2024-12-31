using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSight : MonoBehaviour
{
    [SerializeField] Character hero;
    [SerializeField] Transform barrierPoint;

    private void Awake()
    {
        hero.SetTargetPos(barrierPoint);
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
        if(other.CompareTag("Zombie"))
        {
            hero.SetTargetPos(barrierPoint.transform);
        }
    }
}
