using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPauseUI : UICanvas
{
    public static CanvasPauseUI Instance { get; private set; }  
    [SerializeField] private Animator animator;
    private void Awake()
    {
        Instance = this;
    }
    public void ShowPauseUIAnimationStart()
    {
        animator.SetTrigger(Constants.ANIM_PAUSE_UI_START);
    }

    public void ShowPauseUIAnimationEnd()
    {
        animator.SetTrigger(Constants.ANIM_PAUSE_UI_END);
       
    }

    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        ShowPauseUIAnimationEnd();
        StartCoroutine(ClosePauseUIForPlayGameButton());
        //UIManager.Ins.CloseUIDirectly<CanvasPauseUI>();
    }
    
    public void OpenMainMenu()
    {
        Time.timeScale = 1f;
        ShowPauseUIAnimationEnd();
        StartCoroutine(ClosePauseUIForOpenMainMenu());
    }
    private IEnumerator ClosePauseUIForPlayGameButton()
    {
        yield return new WaitForSeconds(1.0f);
        UIManager.Ins.CloseUIDirectly<CanvasPauseUI>();
    }
    private IEnumerator ClosePauseUIForOpenMainMenu()
    {
        yield return new WaitForSeconds(1.0f);
        UIManager.Ins.CloseUIDirectly<CanvasPauseUI>();
        UIManager.Ins.CloseUIDirectly<CanvasGamePlay>();
        UIManager.Ins.OpenUI<CanvasMainMenu>();
        CanvasMainMenu.Instance.ShowAnimationMainMenuIdle();
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;  
    }
    public void OnRetryLevel()   
    {
        ShowPauseUIAnimationEnd();
        LevelManager.Ins.OnRetryLevel();
        PlayGame();
    }
    
}
