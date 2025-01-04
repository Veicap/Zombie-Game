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
    [SerializeField] private float offsetRange = 0.2f;
    [SerializeField] private float speedRotation = 3f;

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;

    private const string WALK = "Walk";
    private const string DEAD = "Dead";
    private const string ATTACK = "Attack";

    private IState currentState;
    private Transform targetTransform;
    private bool isMoving;
    private float attackCooldown;


    public IState CurrentState => currentState;
    public float AttackSpeed => attackSpeed;
    public bool IsDead => health <= 0;
    public Transform TargetTransform => targetTransform;
    public float AttackRange => attackRange;


    
    public virtual void Start()
    {
        OnInit();
    }

    public virtual void Update()
    {
        CurrentState?.OnExecute(this);
    }

    public void SetTargetPos(Transform targetTransfrorm)
    {
        targetTransform = targetTransfrorm;
    }
    public virtual void OnInit()
    {
        currentState = new MoveState();
        isMoving = false;
        attackCooldown = AttackSpeed;
    }

    public virtual void OnAttack()
    {
        // Chuyen animation dua tren toc danh cua nhan vat
        attackCooldown += Time.deltaTime;
        if (attackCooldown >= AttackSpeed)
        {
            attackCooldown = 0f;
            ChangeAnimation(ATTACK);
        }
    }


    public void OnMove()
    {
        // Tranh tinh trang update move lien tuc
        if (!isMoving)
        {
            ChangeAnimation(WALK);
            isMoving = true;
        }

        MoveToTarget();
    }


    public void OnHit(float damageAmount)
    {
        if(!IsDead)
        {
            health -= damageAmount;

            if (IsDead)
            {
                OnDeath();
            }
        }
        
    }

    protected virtual void OnDeath()
    {
        ChangeAnimation(DEAD);
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

    public bool IsTargetInRange()
    {
        if (TargetTransform == null) return false;
        float distance = Vector3.Distance(transform.position, TargetTransform.position);
        return distance <= AttackRange + offsetRange;
    }
    // sua lai cho hop voi zombie
    public void MoveToTarget()
    {
        if (targetTransform == null || agent == null) return;
        Vector3 destination = targetTransform.position;
        destination.z -= attackRange;
        agent.SetDestination(destination);
    }
    public void StopMoving()
    {
        isMoving = false;
    }
    public bool IsMoving()
    {
        return isMoving;
    }

    // can phai sua lai
    public void RotateTowardsTarget()
    {
        if (TargetTransform == null) return;

        Vector3 direction = (TargetTransform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speedRotation);
       
    }
    public void ResetAttackCoolDown()
    {
        attackCooldown = attackSpeed;
    }
}
