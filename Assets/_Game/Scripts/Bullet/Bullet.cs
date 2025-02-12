using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : GameUnit  
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float damage = 20f;
    [SerializeField] private GameObject hitEffect;

    public void MoveForward(Transform targetTransform)
    {
        transform.parent = null;
        //Vector3 tTransform = targetTransform.localPosition;
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        direction.y += 0.2f;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zombie"))
        {
            Debug.Log("Trigger");
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Zombie zombie = other.GetComponent<Zombie>();
            zombie.OnHit(damage);
            SimplePool.Despawn(this);
        }
    }
}
