using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameOver : UICanvas
{
    public static CanvasGameOver Instance { get; private set; }
    [SerializeField] private Animator animator;

    private void Awake()
    {
        Instance = this;
    }
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
        StartCoroutine(ClosePauseUIForOpenMainMenu());
    }

    private IEnumerator ClosePauseUIForOpenMainMenu()
    {
        yield return new WaitForSeconds(1.0f);

        UIManager.Ins.CloseUIDirectly<CanvasGamePlay>();
        yield return new WaitUntil(() =>
            !UIManager.Ins.IsOpened<CanvasGamePlay>());
        UIManager.Ins.OpenUI<CanvasMainMenu>();
        CanvasMainMenu.Instance.ShowAnimationMainMenuIdle();
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
