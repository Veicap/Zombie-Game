using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossZombie : Zombie
{
    [SerializeField] private GameObject lightitngImpact;
    [SerializeField] private GameObject attackEffect;
    [SerializeField] private Transform pointToSpawnAttackEffect;
    private IBossState currentState;
    public bool deadFirstTime = false;
    public bool deadSecondTime = false;
    public bool revised = false;
    public override void Update()
    {
        currentState.OnExecute(this);
        //Debug.Log(currentState);
        Debug.Log(IsDead());
    }
    public override void OnHit(float damageAmount)
    {
        base.OnHit(damageAmount);
        if (!deadFirstTime)
        {
            float percentHp = 1 - (hp / maxHP);
            float offset = percentHp / 30;
            ScaleLightingImpace(offset);
        }
        
    }

    public override void OnInit(int hpNeedToSpawn)
    {
        base.OnInit(hpNeedToSpawn);
        currentState = new IdleBossState();
        deadFirstTime = false;
        deadSecondTime = false;
    }
    public void ChangeState(IBossState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState?.OnEnter(this);
    }
    public void ScaleLightingImpace(float offset)
    {
        Vector3 localScaleNeedUpdate = lightitngImpact.transform.localScale;
        localScaleNeedUpdate.x += offset;
        localScaleNeedUpdate.y += offset;
        localScaleNeedUpdate.z += offset;
        lightitngImpact.transform.localScale = localScaleNeedUpdate;
    }

    public void OnRivise(int hpNeedToRevise)
    {
        characterCollider.enabled = true;
        maxHP = hpNeedToRevise;
        hp = hpNeedToRevise;
        revised = true;
        attackCooldown = AttackSpeed -1f;
        isAttacking = false;
        hBar.OnInit(hpNeedToRevise, this);
        agent.speed = originalSpeed + 1f;
    }

    public bool IsDeadFirstTime()
    {
        if (!deadFirstTime && hp < 0) return true;
        return false;
    }
    public bool IsDeadSecondTime()
    {
        if (deadFirstTime && !deadSecondTime && revised && hp < 0) return true;
        return false;
    }

    public override void OnAttack()
    {
        base.OnAttack();
    }
    public override void SpawnAttackEffect()
    {
        base.SpawnAttackEffect();
        Instantiate(attackEffect, pointToSpawnAttackEffect.position, Quaternion.identity);
    }
}
