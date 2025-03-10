﻿    using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawnHero : MonoBehaviour
{
    [SerializeField] private Hero heroToSpawn;
    [SerializeField] private Button buttonSpawnHero;
    [SerializeField] private TextMeshProUGUI manaToSpawnHero;
    [SerializeField] private Image background;
    [SerializeField] private Image countDownToSpawnImage;
    [SerializeField] private Image heroImage;
    public int slotIndex;


    private float timeToSpawnHero;
    public float counter;
    private RectTransform rectTransform;
    private const float offsetChangePosRect = 30f;
    private bool isSpawnHeroUIEnabled;
    private Vector3 originPos;
    Coroutine c;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originPos = rectTransform.position;
        OnInit();
    }

    public void OnInit()
    {
        if (c != null)
        {
            StopCoroutine(c);
        }
        ShowBackGround();
        //buttonSpawnHero.interactable = false;
        manaToSpawnHero.text = heroToSpawn.ManaToSpawn.ToString();
        timeToSpawnHero = heroToSpawn.TimeToSpawn;
        counter = timeToSpawnHero;
        isSpawnHeroUIEnabled = false;
        countDownToSpawnImage.fillAmount = 1;
        rectTransform.position = originPos;
        c = StartCoroutine(UnlockSpawnHero());
    }

    //public static void 

    private void Update()
    {       
        if (CanSpawnHeroUI() && !isSpawnHeroUIEnabled)
        {
            EnableSpawnHeroUI();
            isSpawnHeroUIEnabled = true;
        }
        if(!CanSpawnHeroUI() && isSpawnHeroUIEnabled)
        {
            DisAbleSpawnHeroUI();
            isSpawnHeroUIEnabled = false;
        }
        
    }

    private bool CanSpawnHeroUI()
    {
        return LevelManager.Ins.NumberOfMana >= heroToSpawn.ManaToSpawn && counter < 0;
    }

    // reference by button
    public void SpawnHero()
    {
        //spawn hero
        LevelManager.Ins.OnSpawnHero(heroToSpawn.PoolType);
        // Reduce Mana
        LevelManager.Ins.ReduceManaOfGame(heroToSpawn.ManaToSpawn);
        // lock spawn hero
        LockSpawnHero();
        // Unlock spawn hero
         c = StartCoroutine(UnlockSpawnHero());
    }

    private void DisAbleSpawnHeroUI()
    {
        ShowBackGround();
        isSpawnHeroUIEnabled = false;
        //buttonSpawnHero.interactable = false;
        //ChangePositionOfRectransfor(-offsetChangePosRect);
    }

    private void LockSpawnHero()
    {
        counter = timeToSpawnHero;
        countDownToSpawnImage.fillAmount = 1;
    }

    /*private void ChangePositionOfRectransfor(float numberOfOffset)
    {
        Vector2 currentPos = rectTransform.anchoredPosition;
        currentPos.y += numberOfOffset;
        rectTransform.anchoredPosition = currentPos;
    }*/

    private IEnumerator UnlockSpawnHero()
    {
        while (counter > 0)
        {
            counter -= Time.deltaTime;
            countDownToSpawnImage.fillAmount = counter / timeToSpawnHero;
            yield return null;
        }
    }
    private void EnableSpawnHeroUI()
    {
        buttonSpawnHero.interactable = true;
        HideBackGround();
        //ChangePositionOfRectransfor(offsetChangePosRect);
    }
    private void ShowBackGround()
    {
        background.gameObject.SetActive(true);
        background.raycastTarget = true;
    }
    private void HideBackGround()
    {
        background.raycastTarget = true;
        background.gameObject.SetActive(false);
    }

    public void SetHeroToSpawn(Hero herotoSpawn)
    {
        heroToSpawn = herotoSpawn;
    }

    public void SetSpritesHeroItem(Sprite heroSprite)
    {
        
        heroImage.sprite = heroSprite;
        Debug.Log($"Button {this.name} and {heroImage.sprite.name}");
    }
}
