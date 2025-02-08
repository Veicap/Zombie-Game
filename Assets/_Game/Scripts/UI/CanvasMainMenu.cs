using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : UICanvas
{

   
    public class OnLoadLevelEventArg
    {
        public int level;
    }


    public void OnLoadLevel(int level)
    {
         
        UIManager.Ins.CloseUIDirectly<CanvasMainMenu>();
        UIManager.Ins.OpenUI<CanvasGamePlay>();
        LevelManager.Ins.LoadLevel(level);
        Time.timeScale = 1.0f;
    }

    
}
