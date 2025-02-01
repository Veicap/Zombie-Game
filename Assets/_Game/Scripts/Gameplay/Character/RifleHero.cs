using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RifleHero : GunHero
{
    //private const string V = "Rifle is Character : ";

    [SerializeField] private int numberOfBullet;
    [SerializeField] private float timeToReload;
    
    private int numberOfShoot;
    private IRifleState currentState;
    private bool canCounter = true;
    private bool isReloading = false;
    private void Awake()
    {
        OnInit();
    }
    public override void Update()
    {
        //Debug.Log(Target);
        /*Debug.Log(currentState);
        Debug.Log("Rifle Hero has target: " + HasTarget());*/
        currentState.OnExecute(this);
        Debug.Log("Number of shoot" + numberOfShoot);
        // Debug.Log(attackCooldown);
       // Debug.Log(attackCooldown);
    }
    public override void OnInit()
    {
        base.OnInit();
        numberOfShoot = 0;
        currentState = new IdleRifleState();
    }

    public override void OnAttack()
    {
        if (canCounter && !isReloading)
        {
            attackCooldown += Time.deltaTime;

            if (attackCooldown >= AttackSpeed)
            {
                attackCooldown = 0f;
                canCounter = false;

                if (!target.IsDead())
                {
                    target.OnHit(damage);
                }

                StartCoroutine(OnChangeAttackAnim());

                numberOfShoot += 3;

                
            }
        }
    }

    private IEnumerator OnChangeAttackAnim()
    {
        ChangeAnimation(Constants.ANIM_ATTACK);

        yield return new WaitForSeconds(attackSpeed);

        if (!isReloading)
        {
            canCounter = true;
        }
        if (numberOfShoot >= numberOfBullet)
        {
            StartCoroutine(OnReload());
        }
    }

    private IEnumerator OnReload()
    {
        isReloading = true;
        ChangeAnimation(Constants.ANIM_RELOAD);

        yield return new WaitForSeconds(timeToReload);

        numberOfShoot = 0;
        isReloading = false;
        canCounter = true;
    }

    public void ChangeState(IRifleState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState?.OnEnter(this);
    }
}
