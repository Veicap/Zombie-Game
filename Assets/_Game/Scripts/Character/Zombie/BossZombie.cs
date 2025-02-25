using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossZombie : Zombie
{
    [SerializeField] private GameObject lightitngImpact;
    private IBossState currentState;
    public bool deadFirstTime = false;
    public bool deadSecondTime = false;

    private void Start()
    {
        OnInit(500);
    }
    public override void Update()
    {
        currentState.OnExecute(this);
        
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
}
