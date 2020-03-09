using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Singleton
    private static SceneController _pSceneController;
    public static SceneController Instance {  get { return _pSceneController; } }

    // Public
    public string[] sceneNames;
    public int initialScene;

    // Private
    private int loadThisScene = 0;
    private List<int> loadedScenes = new List<int>();
    private const int maxScenesLoaded = 1;
    private int currentLevel;

    private void Awake()
    {
        currentLevel = initialScene;

        // Singleton
        if (_pSceneController != null && _pSceneController != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _pSceneController = this;
        }

        Debug.Log("Load initial scene: " + sceneNames[initialScene - 1]);

        // Load first scene
        LoadAsyncScene(initialScene - 1);

        // For the function
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene loadedScene, LoadSceneMode sceneMode)
    {
        Debug.Log("Scene successfully loaded: " + loadedScene.name);

        // Don't make the main scene the main scene
        if (loadedScene.name != "MainScene")
        {
            // Set new scene as active
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneNames[loadThisScene]));
        }

        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("FadeIn");
    }

    public void LoadAsyncScene(int sceneIndex)
    {
        Debug.Log("Attempting to load scene: " + sceneNames[sceneIndex]);

        // If loaded scene is currently active, return
        if (SceneManager.GetActiveScene().name == sceneNames[sceneIndex]) { return; }

        // Reached max scenes loaded
        if (loadedScenes.Count >= maxScenesLoaded)
        {
            // Unloads scene
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(sceneNames[loadedScenes[0]]));
            // Removes it from the list
            loadedScenes.RemoveAt(0);
        }

        // Adds the new scene to the list
        loadedScenes.Add(sceneIndex);
        // Loads the new scene
        SceneManager.LoadScene(sceneNames[sceneIndex], LoadSceneMode.Additive);
        loadThisScene = sceneIndex;
    }

    public void LoadNextLevel()
    {
        LoadAsyncScene(currentLevel);

        currentLevel += 1;

        // Temp code
        if (currentLevel == 5)
        {
            GameObject.FindObjectOfType<TempMusicManager>().PlayBossMusic();
        }
    }

    public void ReloadCurrentScene()
    {
        SceneManager.UnloadSceneAsync(sceneNames[currentLevel - 1]);

        SceneManager.LoadScene(sceneNames[currentLevel - 1], LoadSceneMode.Additive);
    }
}
