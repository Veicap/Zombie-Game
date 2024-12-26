using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float hp;
    public float damage;
    public float speed;
    public Animator animator;

    // Khoi tao nhan vat
    public virtual void OnInit()
    {

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
    public virtual void OnHit(float damage)
    {

    }
    // Ham xu ly khi nhan vat chet
    public void OnDeadth()
    {

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

}
