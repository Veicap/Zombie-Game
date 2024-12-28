using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Transform zombiePoint;

    public Transform ZombiePoint => zombiePoint;
}
