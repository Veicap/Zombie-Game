using UnityEngine;

public class MeleeHero : Character
{
    private const string WALK = "Walk";
    private const string ATTACK = "Attack";

    [SerializeField] private Camera m_camera;
    [SerializeField] private float offsetRange = 0.2f;

    private float attackCooldown;
    private bool isMoving;

    
    

    private void Start()
    {
        OnInit();
    }

    public override void OnInit()
    {
        base.OnInit();
        attackCooldown = AttackSpeed;
        isMoving = false;
    }

    private void Update()
    {
        CurrentState?.OnExecute(this);
        Debug.Log(IsTargetInRange());
    }

    public override void OnAttack()
    {
        attackCooldown += Time.deltaTime;
        if (attackCooldown >= AttackSpeed)
        {
            attackCooldown = 0f;
            ChangeAnimation(ATTACK);
        }
    }

    public override void OnMove()
    {
        if (!isMoving)
        {
            ChangeAnimation(WALK);
            isMoving = true;
        }

        MoveToTarget();
    }

    public bool IsTargetInRange()
    {
        if (TargetTransform == null) return false;
        float distance = Vector3.Distance(transform.position, TargetTransform.position);
        return distance <= AttackRange + offsetRange;
    }
    public void SetAttackCoolDown(float attackCoolDown)
    {
        attackCooldown = attackCoolDown;
    }

    public void ChangeStateHeroNotMoving()
    {
        isMoving = false;
    }
    public void RotateTowardsTarget()
    {
        if (TargetTransform == null) return;

        Vector3 direction = (TargetTransform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
        Debug.Log("Rotate");
    }
}
