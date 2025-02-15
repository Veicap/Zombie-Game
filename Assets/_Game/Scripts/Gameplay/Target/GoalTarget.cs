using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTarget : MonoBehaviour, ITarget
{
    [SerializeField] private float maxHp;
    [SerializeField] private Transform goalPos;
    [SerializeField] private Vector3 offsetHeathBar;
    [SerializeField] private TurretType turretType;

    protected HealthBar hBar;
    private float hp;

    public void OnInit()
    {
        hp = maxHp;
        if(turretType == TurretType.Turret_Enemy)
        {
            hBar = SimplePool.Spawn<HealthBar>(PoolType.HealBar_Zombie, transform.position, Quaternion.identity);
        }
        if (turretType == TurretType.Turret_Hero)
        {
            hBar = SimplePool.Spawn<HealthBar>(PoolType.HealBar_Hero, transform.position, Quaternion.identity);
        }
        hBar.OnInit(maxHp, this);
        //  Debug.Log(hBar);
    }

    public Vector3 GetOffsetHealthBar()
    {
        return offsetHeathBar;
    }

    public bool IsDead() => hp <= 0;
    public void OnHit(float damageAmount)
    {
        if (!IsDead())
        {
            //Debug.Log(damageAmount);
            hp -= damageAmount;
            hBar.SetNewHP(hp);
            if (IsDead())
            {
                OnDeath();
            }
        }

    }
    public void OnDeath()
    {
      //  Debug.Log("End Game");
        if(turretType == TurretType.Turret_Enemy)
        {
            UIManager.Ins.OpenUI<CanvasLevelCompleteUI>();
        }
        if (turretType == TurretType.Turret_Hero)
        {
            UIManager.Ins.OpenUI<CanvasGameOver>();
        }
    }

    public Transform GetTransform()
    {
        return goalPos;
    }

    public void OnDespawn()
    {
       
    }

    public Vector3 GetPosition()
    {
       return transform.position;   
    }
}

public enum TurretType
{
    Turret_Hero =1,
    Turret_Enemy =2,
}
