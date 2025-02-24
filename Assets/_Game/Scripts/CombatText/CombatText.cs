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
                Debug.Log(counter);
                onInit = false;
                OnDespawn();
            }
        }
    }

    public void OnInit(float damage, Character character)
    {
        counter = 0;
        combatText.text = damage.ToString();
        animator.SetTrigger(Constants.ANIM_COMBAT_TEXT);
        if (character is Hero)
        {
            combatText.color = Color.white;
        }
        if (character is Zombie)
        {
            combatText.color = Color.red;
        }
        onInit = true;
        Debug.Log(onInit);
    }
    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
}
