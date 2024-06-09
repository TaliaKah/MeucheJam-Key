using UnityEngine;

public class EndDoor : MonoBehaviour
{
    public ItemID requiredKey1;
    public ItemID requiredKey2;
    public ItemID requiredKey3;
    public ItemID requiredKey4;

    private GameManager manager;
    private DialogEvents dialogs;

    private bool tryOpen = false;

    private bool isReach = false;

    private void Start()
    {
        manager = GameManager.Instance;
        dialogs = DialogEvents.Instance;
        InputManager.Instance.interactionEvent.AddListener(Interact);
    }

    public void Interact()
    {
        if(isReach && PlayerItems.HasItem(requiredKey1) && PlayerItems.HasItem(requiredKey2) && PlayerItems.HasItem(requiredKey3) && PlayerItems.HasItem(requiredKey4))
        {
                Destroy(gameObject); 
                PlayerItems.RemoveItem(requiredKey1);
                PlayerItems.RemoveItem(requiredKey2);
                PlayerItems.RemoveItem(requiredKey3);
                PlayerItems.RemoveItem(requiredKey4);
        }
        else if(isReach && !tryOpen && PlayerItems.HasItem(requiredKey1) && PlayerItems.HasItem(requiredKey2) && PlayerItems.HasItem(requiredKey3) && PlayerItems.HasItem(requiredKey4))
        {
            dialogs.NeedMysteryKeyNow();
            tryOpen = false;
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
