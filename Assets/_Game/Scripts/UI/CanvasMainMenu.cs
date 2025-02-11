using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : UICanvas
{
    public static CanvasMainMenu Instance {  get; private set; } 

    [SerializeField] private Animator animator;


    private void Awake()
    {
        Instance = this;
    }
    public void ShowAnimationMainMenuEnd()
    {
        animator.SetTrigger(Constants.ANIM_MAINMENU_UI_END);
    }

    public void ShowAnimationMainMenuStart()
    {
        animator.SetTrigger(Constants.ANIM_MAINMENU_UI_START);
    }

    public void ShowAnimationMainMenuIdle()
    {
        animator.SetTrigger(Constants.ANIM_MAINMENU_UI_IDLE);
        Debug.Log("Anim Main Menu Idle");
    }

    void Start()
    {
       
        animator.Play("IdleState");
    }

    public class OnLoadLevelEventArg
    {
        public int level;
    }

    public void OnLoadLevel(int level)
    {
        StartCoroutine(ShowMainMenuAnim(level));
    }

    private IEnumerator ShowMainMenuAnim(int level)
    {
        ShowAnimationMainMenuEnd();
        yield return new WaitForSeconds(2f);
        UIManager.Ins.CloseUIDirectly<CanvasMainMenu>();
        UIManager.Ins.OpenUI<CanvasGamePlay>();
        LevelManager.Ins.LoadLevel(level);
        Time.timeScale = 1.0f;
    }
    
}
