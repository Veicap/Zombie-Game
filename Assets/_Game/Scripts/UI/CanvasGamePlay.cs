using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGamePlay : UICanvas
{
    //[SerializeField] private Button pauseGame;
    public static CanvasGamePlay Instance { get; private set; }
    [SerializeField] private List<ButtonSpawnHero> buttonSpawnHeroes;

    private void Awake()
    {
        Instance = this;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        UIManager.Ins.OpenUI<CanvasPauseUI>();
    }

    public void OnInit()
    {
        foreach (var button in buttonSpawnHeroes)
        {
            button.OnInit();
        }
    }
}
