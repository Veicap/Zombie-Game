using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace Editor
{
    public class ScriptRestarter : MonoBehaviour
    {
        [MenuItem("Helpers/Restart Scene #R")]
        private static void RestartScene()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}

