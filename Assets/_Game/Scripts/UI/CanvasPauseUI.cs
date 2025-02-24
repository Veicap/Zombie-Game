using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPauseUI : UICanvas
{
    [SerializeField] private Animator animator;
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

    private IEnumerator ClosePauseUIForPlayGameButton()
    {
        yield return new WaitForSeconds(1.0f);
        UIManager.Ins.CloseUIDirectly<CanvasPauseUI>();
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 1f;
        ShowPauseUIAnimationEnd();
        StartCoroutine(ClosePauseUIForOpenMainMenu());
    }
    
    private IEnumerator ClosePauseUIForOpenMainMenu()
    {
        yield return new WaitForSeconds(1.0f);
        
        UIManager.Ins.CloseUIDirectly<CanvasGamePlay>();
        yield return new WaitUntil(() =>
            !UIManager.Ins.IsOpened<CanvasGamePlay>());
        // Doi 2 Canvas kia ddong lai da moi bat dau mo Main Menu
        UIManager.Ins.OpenUI<CanvasMainMenu>();
        CanvasMainMenu.Instance.ShowAnimationMainMenuIdle();
       /* if (CanvasMainMenu.Instance != null)
        {
            CanvasMainMenu.Instance.ShowAnimationMainMenuIdle();
        }*/
      
        yield return new WaitForSecondsRealtime(1f);
        UIManager.Ins.CloseUIDirectly<CanvasPauseUI>();
        Time.timeScale = 0f;

    }
    public void OnRetryLevel()   
    {
        ShowPauseUIAnimationEnd();
        LevelManager.Ins.OnRetryLevel();
        PlayGame();
    }
    
}
