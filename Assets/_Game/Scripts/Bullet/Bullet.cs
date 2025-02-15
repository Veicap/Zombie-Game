using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : GameUnit  
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float damage = 20f;
    public LayerMask hitLayers;
    private float counter = 0;

    
    private void Update()
    {
        counter += Time.deltaTime;
        if (counter > 5f)
        {
            OnDespawn();
            counter = 0;
        }
        
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = rb.velocity.normalized;
        Debug.DrawRay(rayOrigin, rayDirection * speed * Time.fixedDeltaTime, Color.red);


        if (Physics.Raycast(rayOrigin, rayDirection, out hit, speed * Time.fixedDeltaTime, hitLayers))
        {
            if (hit.collider.TryGetComponent<Zombie>(out var zombie))
            {
                Effect effect = zombie.SpawnHitEffect(transform);
                LevelManager.Ins.DespawnEffect(effect);
                OnDespawn();
                zombie.OnHit(damage);
            }
        }
    }
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
        if (other.CompareTag("Zombie"))
        {
            Zombie zombie = other.GetComponent<Zombie>();
            Effect effect = zombie.SpawnHitEffect(transform);
            LevelManager.Ins.DespawnEffect(effect);
            OnDespawn();
            zombie.OnHit(damage);
        }
    }

    private void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
}
