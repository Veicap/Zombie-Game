using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberOfManaText;
    [SerializeField] private Image manaBarImage;

    private float numberOfMana;
    private float maxMana;

    private void Awake()
    {
        maxMana = LevelManager.Ins.MaxMana;
    }

    private void Update()
    {
        numberOfMana = LevelManager.Ins.NumberOfMana;
        numberOfManaText.text = numberOfMana.ToString();
        manaBarImage.fillAmount = numberOfMana / maxMana;
    }
}
