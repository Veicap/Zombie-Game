using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    Dictionary<System.Type, UICanvas> canvasActives = new Dictionary<System.Type, UICanvas>();
    Dictionary<System.Type, UICanvas> canvasPrefabs = new Dictionary<System.Type, UICanvas>();
    [SerializeField] Transform parent;

    private void Awake()
    {
        // Load ui prefab tu resources
        UICanvas[] canvases = Resources.LoadAll<UICanvas>("UI/");
        Debug.Log("Number of canvases " +  canvases.Length);
        foreach (var canv in canvases)
        {
            canvasPrefabs.Add(canv.GetType(), canv);
            Debug.Log(canv.GetType());
            Debug.Log("Load Resource Complete!");
        }
        
    }
    // mo canvas
    public T OpenUI<T>() where T : UICanvas
    {
        T canvas = GetUI<T>();
        canvas.SetUp(); // Khi mo len la set up chang han nhu truong hop update score
        canvas.Open(); // set active cho canvas

        return canvas;
    }
    // dong canvas sau time
    public void CloseUI<T>(float time) where T : UICanvas
    {
        if (IsLoaded<T>())
        {
            canvasActives[typeof(T)].Close(time);
        }
    }
    // dong canvas truc tiep
    public void CloseUIDirectly<T>() where T : UICanvas
    {
        if (IsLoaded<T>())
        {
            canvasActives[typeof(T)].CloseDirectly();
        }
    }
    // kiem tra canvas da duoc toa hay chua
    public bool IsLoaded<T>() where T : UICanvas
    {
        return canvasActives.ContainsKey(typeof(T)) && canvasActives[typeof(T)] != null;
    }
    // kiem tra canvas da dc mo hay chua
    public bool IsOpened<T>() where T : UICanvas
    {
        return IsLoaded<T>() && canvasActives[typeof(T)].gameObject.activeSelf;
    }
    // lay active canvs
    public T GetUI<T>() where T : UICanvas
    {
        if (!IsLoaded<T>())
        {
            T prefab = GetUIPrefab<T>();
            T canvas = Instantiate(prefab, parent);
            canvasActives[typeof(T)] = canvas;
        }
        return canvasActives[typeof(T)] as T;
    }
    private T GetUIPrefab<T>() where T : UICanvas
    {
        return canvasPrefabs[typeof(T)] as T;
    }
    // dong tat ca
    public void CloseAll()
    {
        foreach (var canvas in canvasActives)
        {
            if (canvas.Value != null && canvas.Value.gameObject.activeSelf)
            {
                canvas.Value.Close(0);
            }
        }
    }
}
