using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : GameUnit
{
    [SerializeField] Image imageFill;
    [SerializeField] Vector3 offset;
    [SerializeField] PoolType poolType  ;

    private float hp;
    private float maxHp;
    private Transform target;
    private void Update()
    {
        if (imageFill != null && maxHp > 0)
        {
            imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp / maxHp, Time.deltaTime * 5f);
        }

        if (target != null)
        {
            transform.position = target.position + offset;
        }
        //Debug.Log("RealHp" + this.hp);
    }

    public void OnInit(float maxHp, Transform target)
    {
        this.maxHp = maxHp;
        hp = this.maxHp;
        this.target = target;
        imageFill.fillAmount = 1f;
        transform.position = target.position + offset;
    }

    public void SetNewHP(float health)
    {
        hp = health;
        //Debug.Log("HP Updated: " + this.hp);
    }
}
