using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGamePlay : UICanvas
{
    //[SerializeField] private Button pauseGame;


    public void PauseGame()
    {
        Time.timeScale = 0;
        UIManager.Ins.OpenUI<CanvasPauseUI>();
    }
}
