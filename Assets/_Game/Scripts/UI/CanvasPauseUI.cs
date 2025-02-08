using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPauseUI : UICanvas
{
    //public static event EventHandler OnReTryLevel;
   
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        UIManager.Ins.CloseUIDirectly<CanvasPauseUI>();
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 0f;
        UIManager.Ins.CloseUIDirectly<CanvasPauseUI>();
        UIManager.Ins.OpenUI<CanvasMainMenu>();
        UIManager.Ins.CloseUIDirectly<CanvasGamePlay>();
    }

    public void OnRetryLevel()   
    {
        LevelManager.Ins.OnRetryLevel();
        PlayGame();
    }
    
}
