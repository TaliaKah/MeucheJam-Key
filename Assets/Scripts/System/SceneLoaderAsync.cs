// Source : https://myriadgamesstudio.com/how-to-use-the-unity-scenemanager/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderAsync : Singleton<SceneLoaderAsync>
{

    // Loading Progress: private setter, public getter
    private float _loadingProgress;
    public float LoadingProgress => _loadingProgress;

    [SerializeField] private Text Text = null;

    private void Start()
    {
        if (this == SceneLoaderAsync.Instance)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
    {
        // kick-off the one co-routine to rule them all
        Debug.Log($"Load kicked-off: {sceneName}");
        StartCoroutine(LoadScenesInOrder(sceneName, mode));
    }

    private IEnumerator LoadScenesInOrder(string sceneName, LoadSceneMode mode)
    {
        // LoadSceneAsync() returns an AsyncOperation, 
        // so will only continue past this point when the Operation has finished
        // yield return SceneManager.LoadSceneAsync("Loading");

        // This works
        // SceneManager.LoadScene("Loading");
        // Debug.Log($"Loading screen loaded.");
        // yield return new WaitForSeconds(0.1f);

        // as soon as we've finished loading the loading screen, start loading the game scene
        yield return StartCoroutine(LoadSceneWithProgress(sceneName, mode));
    }

    private IEnumerator LoadSceneWithProgress(string sceneName, LoadSceneMode mode)
    {
        Debug.Log($"Next scene loading...");
        var asyncScene = SceneManager.LoadSceneAsync(sceneName, mode);

        // Text = GameObject.Find("Progress").GetComponent<Text>();
        if (Text is null)
        {
            Debug.Log($"Couldn't find Progress Text");
        }

        Debug.Log($"Loading scene: {sceneName}...");

        // this value stops the scene from displaying when it's finished loading
        asyncScene.allowSceneActivation = false;

        while (!asyncScene.isDone)
        {
            // Debug.Log(asyncScene.progress);
            // loading bar progress
            _loadingProgress = Mathf.Clamp01(asyncScene.progress / 0.9f) * 100;

            if (Text)
            {
                Text.text = $"Loading... {_loadingProgress}%";
            }

            // scene has loaded as much as possible, the last 10% can't be multi-threaded
            if (asyncScene.progress >= 0.9f)
            {
                // we finally show the scene
                asyncScene.allowSceneActivation = true;
            }

            yield return null;
        }

        Debug.Log($"Load complete: {sceneName}");
    }
}