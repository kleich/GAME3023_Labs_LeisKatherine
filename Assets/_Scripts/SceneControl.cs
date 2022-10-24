using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // Load
    public void LoadScene(Object scene)
    {
        SceneManager.LoadScene(scene.name);
    }
    public void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void LoadScene(int build_index)
    {
        SceneManager.LoadScene(build_index);
    }
    // Load/Save game data 
    public void LoadGameData()
    {
        GameDataManager.Load();
    }
    public void SaveGameData()
    {
        GameDataManager.Save();
    }
    public void DeleteSavedData()
    {
        GameDataManager.Delete();
    }
    // Load Additive
    public void LoadSceneAdditive(Object scene)
    {
        SceneManager.LoadScene(scene.name, LoadSceneMode.Additive);
    }

    public void LoadSceneAdditive(string scene_name)
    {
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
    }
    public void LoadSceneAdditive(int build_index)
    {
        SceneManager.LoadScene(build_index, LoadSceneMode.Additive);
    }

    // Unload
    public void UnLoadScene(Object scene)
    {
        SceneManager.UnloadSceneAsync(scene.name);
    }
    public void UnLoadScene(string scene_name)
    {
        SceneManager.UnloadSceneAsync(scene_name);
    }
    public void UnLoadScene(int build_index)
    {
        SceneManager.UnloadSceneAsync(build_index);
    }

    public void QuitApplication()
    {
        #if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

        #endif

        Application.Quit();
    }
}
