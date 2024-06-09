using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{

    [SerializeField] private SpriteRenderer[] graphisms;
    [SerializeField] private Sprite[] openSprite;
    [SerializeField] private Sprite[] closedSprite;

    [SerializeField] private Item[] content;

    public GameObject Infos;
     
    private GameManager manager;

    private bool isReach = false;
    private bool isOpenned = false;

    private void Start()
    {
        manager = GameManager.Instance;
        InputManager.Instance.interactionEvent.AddListener(Interact);
    }

    public void Interact()
    {
        if(isReach)
        {
            ChangeState(true, openSprite);
        }
        else
        {
            ChangeState(false, closedSprite);
        }
    }

    private void ChangeState(bool state, Sprite[] sprites)
    {
        isOpenned = state;
        if(isOpenned) EmptyChest();

        for (int i = 0; i < graphisms.Length; i++)
        {
            graphisms[i].sprite = sprites[i];
        }
    }

    private void EmptyChest()
    {
        foreach(var item in content)
        {
            PlayerItems.AddItem(item);
            Destroy(Infos);
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
