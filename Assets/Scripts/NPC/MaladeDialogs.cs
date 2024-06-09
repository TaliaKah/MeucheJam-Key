using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.InputSystem;

public class MaladeDialog : MonoBehaviour
{
    public NPCConversation conversation;

    private GameManager manager;

    private bool isReach = false;

    private void Start()
    {
        manager = GameManager.Instance;
        InputManager.Instance.interactionEvent.AddListener(Interact);
    }

    private void Talk(NPCConversation conv)
    {
        ConversationManager.Instance.SetBool("HeartKey", DialogEvents.GetNeedMysteryKey());
        ConversationManager.Instance.StartConversation(conv);
    }
    
    public void Interact()
    {
        if(isReach)
        {
            Talk(conversation);
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
