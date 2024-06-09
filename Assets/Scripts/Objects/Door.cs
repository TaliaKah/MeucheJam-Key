using UnityEngine;

public class Door : MonoBehaviour
{
    public ItemID requiredKey;

    private GameManager manager;

    private bool isReach = false;

    private void Start()
    {
        manager = GameManager.Instance;
        InputManager.Instance.interactionEvent.AddListener(Interact);
    }

    public void Interact()
    {
        if(isReach && PlayerItems.HasItem(requiredKey))
        {
                Destroy(gameObject); 
                PlayerItems.RemoveItem(requiredKey);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isReach = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isReach = false;
        } 
    }
}
