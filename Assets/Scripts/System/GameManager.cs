using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PlayerInput inputs;

    public float delayBeforeLoad = 3f;
    public Image fadeImage;
    public float fadeDuration = 1f;

    public void EndOfTheGame()
    {
        StartCoroutine(LoadSceneWithDelay("EndScene"));
    }

    IEnumerator LoadSceneWithDelay(string sceneName)
    {
        // Fondu au noir
        StartCoroutine(FadeToBlack());

        // Attente
        yield return new WaitForSeconds(delayBeforeLoad);

        // Chargement de la scène
        SceneLoaderAsync.Instance.LoadScene(sceneName);
    }

    IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        Color originalColor = fadeImage.color;
        Color targetColor = Color.black;

        while (elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(originalColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = targetColor;
    }

    public PlayerInput GetInputs()
    {
        return inputs;
    }
}
