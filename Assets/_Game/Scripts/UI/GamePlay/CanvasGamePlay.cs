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

        UIManager.Ins.OpenUI<CanvasPauseUI>().ShowPauseUIAnimationStart();
        
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

    public void SetSpawnHeroForButton(Hero heroSpawnA, int slotIndexA,Sprite spriteA, Hero heroSpawnB, int slotIndexB, Sprite spriteB)
    {
        buttonSpawnHeroes[slotIndexA].SetHeroToSpawn(heroSpawnA);
        buttonSpawnHeroes[slotIndexA].SetSpritesHeroItem(spriteA);
        buttonSpawnHeroes[slotIndexB].SetHeroToSpawn(heroSpawnB);
        buttonSpawnHeroes[slotIndexB].SetSpritesHeroItem(spriteB);
 
    }

    public void SetSpawnHeroForButton(Hero heroSpawnA, int slotIndexA, Sprite sprite)
    {
        buttonSpawnHeroes[slotIndexA].SetHeroToSpawn(heroSpawnA);
        buttonSpawnHeroes[slotIndexA].SetSpritesHeroItem(sprite);
    }
}
