using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatText : GameUnit
{
    [SerializeField] private TextMeshProUGUI combatText;
    public Animator animator;
    private float counter = 0;
    private bool onInit = false;

    private void Update()
    {
        if(onInit)
        {
            counter += Time.deltaTime;
            if(counter > 1.1f)
            {
                onInit = false;
                OnDespawn();
            }
        }
    }

    public void OnInit(float damage, ITarget target)
    {
        counter = 0;
        combatText.text = damage.ToString();
        animator.SetTrigger(Constants.ANIM_COMBAT_TEXT);
        if (target is Hero)
        {
            combatText.color = Color.white;
        }
        if (target is Zombie)
        {
            combatText.color = Color.red;
        }
        if (target is GoalTarget)
        {
            GoalTarget goalTarget = (GoalTarget)target;
            if(goalTarget.GetTurretType == TurretType.Turret_Hero)
            {
                combatText.color = Color.white;
                
            }
            if(goalTarget.GetTurretType == TurretType.Turret_Enemy)
            {
                combatText.color = Color.red;
            }
            
        }
        onInit = true;
    }
    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
}
