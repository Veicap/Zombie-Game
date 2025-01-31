using System;
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

    private float timeToSpawnHero;
    private float counter;
    private RectTransform rectTransform;
    private const float offsetChangePosRect = 30f; 


    private void Awake()
    {
        OnInit();
        rectTransform = GetComponent<RectTransform>();
    }


    public void OnInit()
    {
        buttonSpawnHero.interactable = false;
        manaToSpawnHero.text = heroToSpawn.ManaToSpawn.ToString();
        timeToSpawnHero = heroToSpawn.TimeToSpawn;
        counter = timeToSpawnHero;
    }
    private void Start()
    {
        StartCoroutine(UnlockSpawnHero());
    }

    // reference by button
    public void SpawnHero()
    {
        //spawn hero
        LevelManager.Ins.OnSpawnHero(heroToSpawn.PoolType);
        // lock spawn hero
        LockSpawnHero();
        // Unlock spawn hero
        StartCoroutine(UnlockSpawnHero());
    }

    private void LockSpawnHero()
    {
        ShowBackGround();
        buttonSpawnHero.interactable = false;
        counter = timeToSpawnHero;
        countDownToSpawnImage.fillAmount = 1;
        ChangePositionOfRectransfor(-offsetChangePosRect);
    }

    private void ChangePositionOfRectransfor(float numberOfOffset)
    {
        Vector2 currentPos = rectTransform.anchoredPosition;
        currentPos.y += numberOfOffset;
        rectTransform.anchoredPosition = currentPos;
    }

    private IEnumerator UnlockSpawnHero()
    {
        while (counter > 0)
        {
            counter -= Time.deltaTime;
            countDownToSpawnImage.fillAmount = counter / timeToSpawnHero;
            yield return null;
        }

        buttonSpawnHero.interactable = true;
        HideBackGround();
        ChangePositionOfRectransfor(offsetChangePosRect);
    }

    private void ShowBackGround()
    {
        background.gameObject.SetActive(true);
    }
    private void HideBackGround()
    {
        background.gameObject.SetActive(false);
    }
}
