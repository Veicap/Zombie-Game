using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameOver : UICanvas
{
    public void OnRetryLevel()
    {
        LevelManager.Ins.OnRetryLevel();
        Time.timeScale = 1.0f;
        UIManager.Ins.CloseUIDirectly<CanvasGameOver>();
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 0f;
        UIManager.Ins.CloseUIDirectly<CanvasGameOver>();
        UIManager.Ins.OpenUI<CanvasMainMenu>();
        UIManager.Ins.CloseUIDirectly<CanvasGamePlay>();
    }
}
