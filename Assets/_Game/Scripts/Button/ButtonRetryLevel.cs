using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRetryLevel : MonoBehaviour
{
    public static event EventHandler OnReTryLevel;
    public void RestryLevel()
    {
        OnReTryLevel?.Invoke(this, EventArgs.Empty);
        //PlayGame();
    }
}
