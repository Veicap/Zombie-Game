using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGamePlay : UICanvas
{
    public static CanvasGamePlay Instance { get; private set; }
    [SerializeField] private List<ButtonSpawnHero> buttonSpawnHeroes;

    private void Awake()
    {
        Instance = this;
    }
    public void PauseGame()
    {
        StartCoroutine(PauseWithAnimation());
    }
    private IEnumerator PauseWithAnimation()
    {
        
        Time.timeScale = 1;
       
        UIManager.Ins.OpenUI<CanvasPauseUI>();
       
        CanvasPauseUI.Instance.ShowPauseUIAnimationStart();
        
        yield return new WaitForSeconds(0.5f); 

        Time.timeScale = 0;
    
    }

    public void OnInit()
    {
        foreach (var button in buttonSpawnHeroes)
        {
            button.OnInit();
        }
    }
}
