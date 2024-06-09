using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupWindow : MonoBehaviour
{
    public GameObject window;
    public TextMeshProUGUI contentText;

    private void Start()
    {
        window.SetActive(false);
    }

    public void ShowWindow(string content)
    {
        contentText.text = content;
        window.SetActive(true);
    }

    public void HideWindow()
    {
        window.SetActive(false);
    }
}
