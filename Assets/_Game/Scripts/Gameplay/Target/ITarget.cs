using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    public void OnHit(float damageAmount);
    public void OnDeath();

    public bool IsDead();

    public void OnDespawn();

    public Transform GetTransform();

    public Vector3 GetOffsetHealthBar();

    public Vector3 GetPosition();
}
