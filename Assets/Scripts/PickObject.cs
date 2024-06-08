using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickObject : MonoBehaviour
{
    public Item item;
    private GameManager manager;

    private bool isReach = false;

    private void Start()
    {
        manager = GameManager.Instance;
        InputManager.Instance.interactionEvent.AddListener(Interact);
    }
    
    public void Interact()
    {
        if(isReach)
        {
            if (PlayerItems.AddItem(item))
            {
                Destroy(gameObject); 
            }
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
