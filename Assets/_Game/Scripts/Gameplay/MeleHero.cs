using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleHero : Character
{
    private const string WALK = "Walk";
    private const string ATTACK = "Attack";
    private const string DEADTH = "Deadth";
    private void Start()
    {
        OnInit();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            OnAttack();
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeAnim(WALK);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnDeadth();
            ChangeAnim(DEADTH);
        }
    }

    public override void OnInit()
    {
        base.OnInit();
        hp = 100f;
        damage = 20f;
        speed = 5f;
    }

    public override void OnAttack()
    {
        base.OnAttack();
        ChangeAnim(ATTACK);
    }

    public override void OnMove()
    {
        base.OnMove();
    }
    
}
