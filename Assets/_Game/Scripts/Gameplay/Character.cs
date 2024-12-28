using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public float hp;
    public float damage;
    public Animator animator;
    public IState currentState;
    private const string DEAD = "Dead";
    private bool isDead;
    public NavMeshAgent agent;

    private Transform destination;
    public float attackRange;
    public float attackSpeed;

    public bool IsDead => isDead;   


    // Khoi tao nhan vat
    public virtual void OnInit()
    {
        currentState = new MoveState();
        isDead = false;
    }
    // Attack
    public virtual void OnAttack()
    {

    }
    // Di chuyen
    public virtual void OnMove()
    {

    }


    // Nhan Damage
    public void OnHit(float damage)
    {
        hp -= damage;
        if(hp < 0)
        {
            if(!isDead)
            {
                OnDeadth();
                isDead = true;
            }
            
        }
    }
    // Ham xu ly khi nhan vat chet
    public void OnDeadth()
    {
        ChangeAnim(DEAD);
    }
    // Xoa nhan vat khoi game
    public void OnDespawn()
    {
        // Destroy(gameObject);
    }

    public void ChangeAnim(string nameAnim)
    {
        animator.SetTrigger(nameAnim);
    }

    public void ChangeState(IState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    }
    public void SetTargetPos(Transform targetTransform)
    {
        this.destination = targetTransform;
    }
    public Transform TargetTransform => destination;    

    public void SetDestination(Transform destination)
    {
        this.destination = destination;
        agent.SetDestination(this.destination.position);
    }
}
