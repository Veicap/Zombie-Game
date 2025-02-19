using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : GameUnit
{
    [SerializeField] Image imageFill;
    //[SerializeField] Vector3 offset;
    //[SerializeField] PoolType poolType;

    private float hp;
    private float initHp;
    private ITarget target;
    private void Update()
    {
        if (imageFill != null && initHp > 0)
        {
            imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp / initHp, Time.deltaTime * 5f);
        }
        if (target != null)
        {
            transform.position = target.GetOffsetHealthBar() + target.GetPosition();
        }
    }
    public void OnInit(float hpNeedToSpawn, ITarget target)
    {
        initHp = hpNeedToSpawn;
        //Debug.Log(hpNeedToSpawn);
        hp = initHp;
        this.target = target;
        imageFill.fillAmount = 1f;
        transform.position = target.GetOffsetHealthBar() + target.GetPosition();
    }

    public void SetNewHP(float health)
    {
        hp = health;
        //Debug.Log("HP Updated: " + this.hp);
    }
}
