using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameOver : UICanvas
{
    [SerializeField] private Animator animator;

    public void OnRetryLevel()
    {
        Time.timeScale = 1.0f;
        ShowGameOverUIAnimationEnd();
        StartCoroutine(CloseGameOverUIForPlayGameButton());
    }

    private IEnumerator CloseGameOverUIForPlayGameButton()
    {
        yield return new WaitForSeconds(1.0f);
        LevelManager.Ins.OnRetryLevel();
        UIManager.Ins.CloseUIDirectly<CanvasGameOver>();
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 1f;
        ShowGameOverUIAnimationEnd();
        StartCoroutine(CloseGameOverUIForOpenMainMenu());
    }

    private IEnumerator CloseGameOverUIForOpenMainMenu()
    {
        yield return new WaitForSeconds(1.0f);
        UIManager.Ins.CloseUIDirectly<CanvasGamePlay>();
        yield return new WaitUntil(() =>
            !UIManager.Ins.IsOpened<CanvasGamePlay>());
        UIManager.Ins.OpenUI<CanvasMainMenu>().ShowAnimationMainMenuIdle();
        
        yield return new WaitForSecondsRealtime(1f);
        UIManager.Ins.CloseUIDirectly<CanvasGameOver>();
        Time.timeScale = 0f;

    }

    public void ShowGameOverUIAnimationStart()
    {
        animator.SetTrigger(Constants.ANIM_GAMEOVER_UI_START);
    }

    public void ShowGameOverUIAnimationEnd()
    {
        animator.SetTrigger(Constants.ANIM_GAMEOVER_UI_END);

    }
}
