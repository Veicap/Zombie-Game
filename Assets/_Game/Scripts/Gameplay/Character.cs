using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour
{
    [Header("Character Attributes")]
    [SerializeField] private float health = 100f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackSpeed = 1.0f;

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;

    private IState currentState;
    private Transform targetTransform;
    private bool isDead;

    public IState CurrentState => currentState;
    public float AttackSpeed => attackSpeed;

    public bool IsDead => isDead;
    public Transform TargetTransform => targetTransform;
    public float AttackRange => attackRange;

    public void SetTargetPos(Transform targetTransfrorm)
    {
        this.targetTransform = targetTransfrorm;
    }
    public virtual void OnInit()
    {
        currentState = new MoveState();
        isDead = false;
    }

    public virtual void OnAttack() { }

    public virtual void OnMove() { }


    public void OnHit(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0 && !isDead)
        {
            isDead = true;
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        ChangeAnimation("Dead");
    }

    public void ChangeAnimation(string animationName)
    {
        if (animator != null)
        {
            animator.SetTrigger(animationName);
        }
    }

    public void ChangeState(IState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState?.OnEnter(this);
    }

    public void MoveToTarget()
    {
        if (targetTransform == null || agent == null) return;

        Vector3 destination = targetTransform.position;
        destination.x -= attackRange;
        agent.SetDestination(destination);
    }
}
