using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLevelCompleteUI : UICanvas
{
    [SerializeField] private Animator animator;
    [SerializeField] GameObject[] stars;

    public override void Open()
    {
        base.Open();
        StartCoroutine(IEStarShow());
    }

    public void OnRetryLevel()
    {
        Time.timeScale = 1.0f;
        ShowLevelCompleteUIAnimationEnd();
        StartCoroutine(CloseLevelCompleteUIForOnRetryLevel());
    }

    private IEnumerator CloseLevelCompleteUIForOnRetryLevel()
    {
        yield return new WaitForSeconds(1.0f);
        LevelManager.Ins.OnRetryLevel();
        UIManager.Ins.CloseUIDirectly<CanvasLevelCompleteUI>();
    }
    public void OpenMainMenu()
    {
        Time.timeScale = 1f;
        ShowLevelCompleteUIAnimationEnd();
        StartCoroutine(CloseLeveCompleteUIForOpenMainMenu());
    }

    private IEnumerator CloseLeveCompleteUIForOpenMainMenu()
    {
        yield return new WaitForSeconds(1.0f);
        UIManager.Ins.CloseUIDirectly<CanvasGamePlay>();
        yield return new WaitUntil(() =>
            !UIManager.Ins.IsOpened<CanvasGamePlay>());
        UIManager.Ins.OpenUI<CanvasMainMenu>().ShowAnimationMainMenuIdle();
   
        yield return new WaitForSecondsRealtime(1f);
        UIManager.Ins.CloseUIDirectly<CanvasLevelCompleteUI>();
        Time.timeScale = 0f;
    }

    public void OnNextLevel()
    {
        LevelManager.Ins.OnNextLevel();
        UIManager.Ins.CloseUIDirectly<CanvasLevelCompleteUI>();
    }

    public void ShowLevelCompleteUIAnimationStart()
    {
        animator.SetTrigger(Constants.ANIM_LEVELCOMPLETE_UI_START);
    }

    public void ShowLevelCompleteUIAnimationEnd()
    {
        animator.SetTrigger(Constants.ANIM_LEVELCOMPLETE_UI_END);
    }

    private IEnumerator IEStarShow()
    {
        //Debug.Log(LevelManager.Ins.StartGiven);
        for (int i = 0; i < LevelManager.Ins.StartGiven; i++)
        {
            yield return new WaitForSeconds(0.5f);
            stars[i].SetActive(true);
        }
    }
}

