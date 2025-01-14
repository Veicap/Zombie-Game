using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTarget : MonoBehaviour, ITarget
{
    [SerializeField] private float health;
    [SerializeField] private Transform goalPos;
    public bool IsDead() => health <= 0;
    public void OnHit(float damageAmount)
    {
        if (!IsDead())
        {
            health -= damageAmount;

            if (IsDead())
            {
                OnDeath();
            }
        }

    }
    public void OnDeath()
    {
        Debug.Log("End Game");
    }

    public Transform GetTransform()
    {
        return goalPos;
    }

    public void OnDespawn()
    {
       
    }
}

