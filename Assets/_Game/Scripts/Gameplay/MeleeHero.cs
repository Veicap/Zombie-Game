using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class MeleeHero : Character
{
    private const string WALK = "Walk";
    private const string ATTACK = "Attack";
    [SerializeField] private Camera m_camera;
    private float counterAttackSpeed;
    private bool isMove;
    
    private void Start()
    {
        OnInit();
        counterAttackSpeed = attackSpeed;
        isMove = false;
    }
    

    public void StopMoving()
    {
        isMove = false;
    }
    public void Update()
    {

        /*if(Input.GetMouseButtonDown(0))
        {
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }*/
        currentState.OnExecute(this);
        Debug.Log(InRangeAttack());
        Debug.Log(TargetTransform);
    }

    public override void OnInit()
    {
        base.OnInit();
        hp = 100f;
        damage = 20f;

    }
    
    public bool InRangeAttack()
    {
        if(Vector3.Distance(transform.position, TargetTransform.position) < attackRange)
        {
            return true;
        }
        return false;
    }
    public override void OnAttack()
    {
        counterAttackSpeed += Time.deltaTime;
        if(counterAttackSpeed > attackSpeed)
        {
            counterAttackSpeed = 0;
            base.OnAttack();
            ChangeAnim(ATTACK);
        }
        
    }
    public void SetIsMove(bool isMove)
    {
        this.isMove = isMove;
    }

    public override void OnMove()
    {
        base.OnMove();
        if (!isMove)
        {
            ChangeAnim(WALK);
            isMove = true;
        }
        SetDestination(TargetTransform);
    }
   
    
}
