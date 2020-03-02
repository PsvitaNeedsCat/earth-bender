using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Public
    public string[] sceneNames;
    public int initialScene;

    // Private
    private int loadThisScene = 0;
    private List<int> loadedScenes = new List<int>();
    private const int maxScenesLoaded = 3;

    private void Awake()
    {
        // Load first scene
        LoadAsyncScene(initialScene - 1);

        // For the function
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene loadedSceneName, LoadSceneMode sceneMode)
    {
        // Don't make the main scene the main scene
        if (loadedSceneName.name != "MainScene")
        {
            // Set new scene as active
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneNames[loadThisScene]));
        }
    }

    public void LoadAsyncScene(int sceneIndex)
    {
        // Reached max scenes loaded
        if (loadedScenes.Count >= maxScenesLoaded)
        {
            // Unloads scene
            SceneManager.UnloadSceneAsync(loadedScenes[0]);
            // Removes it from the list
            loadedScenes.RemoveAt(0);
        }

        // Adds the new scene to the list
        loadedScenes.Add(sceneIndex);
        // Loads the new scene
        SceneManager.LoadScene(sceneNames[sceneIndex], LoadSceneMode.Additive);
        loadThisScene = sceneIndex;
    }
}
