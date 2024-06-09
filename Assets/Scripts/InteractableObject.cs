using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string content = "13";
    private PopupWindow popupWindow;

    private void Start()
    {
        popupWindow = FindObjectOfType<PopupWindow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupWindow.ShowWindow(content);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupWindow.HideWindow();
        }
    }
}
