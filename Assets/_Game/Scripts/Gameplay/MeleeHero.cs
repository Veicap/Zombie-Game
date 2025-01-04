using UnityEngine;

public class MeleeHero : Character
{
    public override void OnInit()
    {
        base.OnInit();
    }
    public override void OnAttack()
    {
        base.OnAttack();
    }

    public override void Update()
    {
        base.Update();
        Debug.Log(TargetTransform.forward);
    }

}
