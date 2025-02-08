using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLevelCompleteUI : UICanvas
{
    public void OnRetryLevel()
    {
        LevelManager.Ins.OnRetryLevel();
        Time.timeScale = 1.0f;
        UIManager.Ins.CloseUIDirectly<CanvasLevelCompleteUI>();
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 0f;
        UIManager.Ins.CloseUIDirectly<CanvasLevelCompleteUI>();
        UIManager.Ins.OpenUI<CanvasMainMenu>();
        UIManager.Ins.CloseUIDirectly<CanvasGamePlay>();
    }

    public void OnNextLevel()
    {
        LevelManager.Ins.OnNextLevel();
        UIManager.Ins.CloseUIDirectly<CanvasLevelCompleteUI>();
    }
}
