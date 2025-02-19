using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public abstract class Character : GameUnit, ITarget
{
    [Header("Character Attributes")]
    [SerializeField] protected float maxHP = 100f;
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float attackRange = 1.5f;
    [SerializeField] protected float attackSpeed = 1.0f;
    [SerializeField] protected float offsetRange = 0.2f;
    [SerializeField] protected float speedRotation = 3f;
    [SerializeField] protected Transform cTransform;
    [SerializeField] protected float timeToDespawn = 3.5f;
    [SerializeField] private Vector3 offsetHealthBar;
    

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    //[SerializeField] private GoalTarget goalTarget;
    [SerializeField] private HealthBar healthBar;
   

    private IState currentState;
    private Transform targetTransform;
    protected float attackCooldown;
    protected bool isMoving;
    protected ITarget target;
    protected float hp;
    protected HealthBar hBar;
    private float originalSpeed;
    protected bool isAttacking;
    private Collider characterCollider;
    

    public IState CurrentState => currentState;
    public float AttackSpeed => attackSpeed;
    public bool IsDead() => hp <= 0;
    public Transform TargetTransform => targetTransform;
    public ITarget Target => target;
    public float AttackRange => attackRange;
    public float Damage => damage;

    private void Awake()
    {
        originalSpeed = agent.speed;
        characterCollider = GetComponent<Collider>();
        //Debug.Log(originalSpeed);
    }
    public virtual void Update()
    {
        currentState?.OnExecute(this);
    }

    public virtual void OnInit(int hpNeedToSpawn)
    {
        hp = maxHP;
        currentState = new IdleState();
        attackCooldown = AttackSpeed;
        isAttacking = false;
        if(this is Hero)
        {
            hBar = SimplePool.Spawn<HealthBar>(PoolType.HealBar_Hero, transform.position, Quaternion.identity);
            hBar.OnInit(hpNeedToSpawn, this);
        }
        if(this is Zombie)
        {
            hBar = SimplePool.Spawn<HealthBar>(PoolType.HealBar_Zombie, transform.position, Quaternion.identity);
            hBar.OnInit(hpNeedToSpawn, this);
        }
        characterCollider.enabled = true;
        agent.speed = originalSpeed;
        
    }

    public virtual void OnAttack()
    {
        ChangeAnimation(Constants.ANIM_ATTACK);
    }

    public void OnMove()
    {
        // Tranh tinh trang update move lien tuc
        if(!isMoving)
        {
            ChangeAnimation(Constants.ANIM_WALK);
            isMoving = true;
            agent.speed = originalSpeed;
        }
        MoveToTarget();
    }
    public void StopMoving()
    {
        isMoving = false;
        agent.speed = 0f;
    }

    public void OnHit(float damageAmount)
    {
        if(!IsDead())
        {
            hp -= damageAmount;
            hBar.SetNewHP(hp);
            if (IsDead())
            {
                OnDeath();
            }
        }
    }

    public virtual void OnDeath()
    {
        characterCollider.enabled = false;
        StopMoving();
        ChangeAnimation(Constants.ANIM_DEAD);
        SimplePool.Despawn(hBar);
        if (this is Hero)
        {
            LevelManager.Ins.RemoveHeroDeadthFromList(this as Hero);
        }
        if (this is Zombie)
        {
            LevelManager.Ins.RemoveZombieDeadthFormList(this as Zombie);
        }
        StartCoroutine(DespawnTarget());
        //Invoke(nameof(OnDespawn), timeToDespawn);
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    private IEnumerator DespawnTarget()
    {
        yield return new WaitForSeconds(timeToDespawn);
        OnDespawn();
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

    // Handle Target Position and move to target

    public void SetTarget(ITarget target)
    {
        this.target = target;
        if(target != null)
        {
            SetTargetTransform(target.GetTransform());
        }
    }

    public void SetTargetTransform(Transform targetTransfrorm)
    {
        targetTransform = targetTransfrorm;
    }

    public Transform GetTransform()
    {
        return cTransform;
    }
    public bool HasTargetInRange()
    {
        if (TargetTransform == null) return false;

        Vector3 myPosition = transform.position;
        Vector3 targetPosition = TargetTransform.position;

        float actualDistance = Vector3.Distance(myPosition, targetPosition);
        Collider targetCollider = TargetTransform.GetComponent<Collider>();

        if (characterCollider != null && targetCollider != null)
        {
            Vector3 myClosestPoint = characterCollider.ClosestPoint(targetPosition);
            Vector3 targetClosestPoint = targetCollider.ClosestPoint(myPosition);
            actualDistance = Vector3.Distance(myClosestPoint, targetClosestPoint);
        }
        return actualDistance <= AttackRange;
    }
    // sua lai cho hop voi zombie
    public void MoveToTarget()
    {
        if (targetTransform == null || agent == null) return;
        Vector3 forwardDirection = targetTransform.forward;
        Vector3 destination = targetTransform.position + forwardDirection ;
        agent.SetDestination(destination);
    }

    public bool HasTarget()
    {
        return target != null;
    }

    public bool HasCharacterTarget()
    {
        if(target is Character) return true;
        return false;
    }
    // can phai sua lai
    public bool RotateTowardsTarget()
    {
        if (TargetTransform == null) return false;
        Vector3 direction = (TargetTransform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speedRotation);
        float angle = Quaternion.Angle(transform.rotation, targetRotation);
        return angle < 1f;

    }
    public void ResetAttackCoolDown()
    {
        attackCooldown = attackSpeed;
    }
    public void ChangeToIdleState()
    {
        // Chuyen sang trang thai ilde
        ChangeAnimation(Constants.ANIM_IDLE);
    }

    public Vector3 GetOffsetHealthBar()
    {
        return offsetHealthBar;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    protected float Health => hp;
}
