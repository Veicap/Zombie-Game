using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] bool isdestroyOnClose = false;


    private void Awake()
    {
        // xu ly tai tho
        /*RectTransform rect = GetComponent<RectTransform>();
        float ratio = (float)Screen.width / (float)Screen.height;
        if (ratio > 2.1f)
        {
            Vector2 leftBottom = rect.offsetMin;
            Vector2 rightTop = rect.offsetMax;
            
            leftBottom.y = 0f;
            rightTop.y = -100f;

            rect.offsetMin = leftBottom;
            rect.offsetMax = rightTop;
        }*/
    }
    // goi truoc khi canvas duoc active
    public virtual void SetUp()
    {

    }
    // goi sau khi dc active
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }
    // dong canvas sau time(s)
    public virtual void Close(float time)
    {
        Invoke(nameof(CloseDirectly), time);
    }
    // dong canvas truc tiep
    public virtual void CloseDirectly()
    {
        if (isdestroyOnClose)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

}
