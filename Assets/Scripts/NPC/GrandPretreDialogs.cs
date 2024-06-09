using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.InputSystem;

public class GrandPretreDialog : MonoBehaviour
{
    public NPCConversation conversation;
    public NPCConversation endConversation;

    private GameManager manager;

    private bool isReach = false;

    private void Start()
    {
        manager = GameManager.Instance;
        InputManager.Instance.interactionEvent.AddListener(Interact);
    }

    private void Talk(NPCConversation conv)
    {
        ConversationManager.Instance.StartConversation(conv);
    }
    
    public void Interact()
    {
        if(isReach)
        {
            if(DialogEvents.GetEndDialog()){
                ConversationManager.Instance.SetBool("FirstSpeak", DialogEvents.GetFirstSpeak());
                Talk(conversation);
            }
            else{
                Talk(endConversation);
                ConversationManager.Instance.SetBool("FirstSpeak", DialogEvents.GetNeedMysteryKey());
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
