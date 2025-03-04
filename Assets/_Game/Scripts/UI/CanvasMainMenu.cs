using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : UICanvas
{
    [SerializeField] private Animator animator;
    [SerializeField] private List<LevelButtonMenu> levelButtonMenu;
    public void ShowAnimationMainMenuEnd()
    {
        animator.SetTrigger(Constants.ANIM_MAINMENU_UI_END);
    }

    public void ShowAnimationMainMenuStart()
    {
        animator.SetTrigger(Constants.ANIM_MAINMENU_UI_START);
    }

    public void ShowAnimationMainMenuIdle()
    {
        animator.SetTrigger(Constants.ANIM_MAINMENU_UI_IDLE);
        Debug.Log("Anim Main Menu Idle");
    }
    public override void Open()
    {
        base.Open();
        for (int i = 0; i < levelButtonMenu.Count; i++)
        {
            levelButtonMenu[i].ShowBestStar(GetBestStars(i + 1));
        }
    }
    void Start()
    {
       
        animator.Play("IdleState");
    }

    public class OnLoadLevelEventArg
    {
        public int level;
    }
    //Button
    public void OnLoadLevel(int level)
    {
        StartCoroutine(ShowMainMenuAnim(level));
    }

    private IEnumerator ShowMainMenuAnim(int level)
    {
        Time.timeScale = 1.0f;
        SimplePool.ReleaseAll();
        LevelManager.Ins.StopSpawnZombie();
        ShowAnimationMainMenuEnd();
        yield return new WaitForSeconds(2f);
        UIManager.Ins.CloseUIDirectly<CanvasMainMenu>();
        UIManager.Ins.OpenUI<CanvasGamePlay>();
        LevelManager.Ins.LoadLevel(level);
    }
    public void SaveBestStar(int level, int newStar)
    {
        string key = GetKeyPlayerPrefs(level);
        int bestStar = PlayerPrefs.GetInt(key);
        Debug.Log(newStar);
        if (newStar > bestStar)
        {
            PlayerPrefs.SetInt(key, newStar);
            PlayerPrefs.Save();
        }
        

    }
    public string GetKeyPlayerPrefs(int level)
    {
        string key = "Level_" + level + "_Stars";
        return key;
    }
    public int GetBestStars(int level)
    {
        string key = GetKeyPlayerPrefs(level);
        return PlayerPrefs.GetInt(key, 0);
    }

    public void OpenInventory()
    {
        UIManager.Ins.OpenUI<CanvasInventory>().OnInit();

    }
    
}

[System.Serializable]
public class StarsLevelObjects
{
    int level;
    public List<GameObject> objects;
}
