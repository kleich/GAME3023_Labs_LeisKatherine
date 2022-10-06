using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void LoadScene(Object scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void LoadSceneAdditive(Object scene)
    {
        SceneManager.LoadScene(scene.name, LoadSceneMode.Additive);
    }

    public void UnLoadScene(Object scene)
    {
        SceneManager.UnloadSceneAsync(scene.name);
    }

    public void QuitApplication()
    {
        #if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

        #endif

        Application.Quit();
    }
}
