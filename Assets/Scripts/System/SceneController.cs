using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Debug.Log("${sceneName} clicked");
        SceneLoaderAsync loader = SceneLoaderAsync.Instance;
        Debug.Log(loader);
        loader.LoadScene(sceneName);
    }
}