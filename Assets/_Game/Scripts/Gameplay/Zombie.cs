using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    [SerializeField] private Transform zombiePoint;

    public Transform ZombiePoint => zombiePoint;
}
