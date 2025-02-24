using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> starImages;
    [SerializeField] private int Level;
    private void Awake()
    {
        for (int i = 0; i < starImages.Count; i++)
        {
            starImages[i].SetActive(false);
        }
    }
   
    public void ShowBestStar(int bestStar)
    {
        starImages[bestStar].SetActive(true);
    }
}
