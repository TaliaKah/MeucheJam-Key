using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] graphisms;
    [SerializeField] private Sprite[] openSprite;
    [SerializeField] private Sprite[] closedSprite;

    private GameManager manager;

    private InputAction interactAction;

    private bool isReach = false;
    private bool isOpenned = false;

    private void Start()
    {
        manager = GameManager.Instance;
        interactAction = manager.GetInputs().actions.FindAction("Interact");
    }

    private void Update()
    {
        float interact = interactAction.ReadValue<float>();
        if(isReach && interact > 0)
        {
            Open();
        }
        else if(!isReach)
        {
            Close();
        }
    }

    private void Open()
    {
        isOpenned = true;
        for (int i = 0; i < graphisms.Length; i++)
        {
            graphisms[i].sprite = openSprite[i];
        }
    }

    private void Close()
    {
        isOpenned = false;
        for (int i = 0; i < graphisms.Length; i++)
        {
            graphisms[i].sprite = closedSprite[i];
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
