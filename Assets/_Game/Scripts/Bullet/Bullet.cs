using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : GameUnit  
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float damage = 20f;

    public void MoveForward(Transform pointToSpawn)
    {
        transform.parent = null;
        rb.velocity = pointToSpawn.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zombie"))
        {
            Debug.Log("Trigger");
            Zombie zombie = other.GetComponent<Zombie>();
            zombie.OnHit(damage);
            SimplePool.Despawn(this);
        }
    }

    

}
