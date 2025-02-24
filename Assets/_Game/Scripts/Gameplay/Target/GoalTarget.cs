using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTarget : MonoBehaviour, ITarget
{
    [SerializeField] private float maxHp;
    [SerializeField] private Transform goalPos;
    [SerializeField] private Vector3 offsetHeathBar;
    [SerializeField] private TurretType turretType;
    [SerializeField] private CombatText combatTextPreb;
    [SerializeField] private Transform pointToSpawnCombatText;
    protected HealthBar hBar;
    private float hp;

    public TurretType GetTurretType
    {
        get { return turretType; }
    }

    public float HP => hp;
    public float MaxHp => maxHp;

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
            CombatText combatText = SimplePool.Spawn<CombatText>(combatTextPreb.PoolType, pointToSpawnCombatText.position, Quaternion.identity);
            combatText.transform.forward = Camera.main.transform.forward;
            combatText.OnInit(damageAmount, this);
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
            LevelManager.Ins.OnWin();
        }
        if (turretType == TurretType.Turret_Hero)
        {
            LevelManager.Ins.OnLose();
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
