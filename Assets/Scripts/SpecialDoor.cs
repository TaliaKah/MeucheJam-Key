using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDoor : MonoBehaviour
{
    public GameObject npcContainer; 
    public ItemID requiredKey;
    public Item endOfGame;

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
            DestroyAllNPCs();
            PlayerItems.AddItem(endOfGame);
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

    private void DestroyAllNPCs()
    {
        if (npcContainer != null)
        {
            foreach (Transform npc in npcContainer.transform)
            {
                Destroy(npc.gameObject);
            }
        }
    }
}
