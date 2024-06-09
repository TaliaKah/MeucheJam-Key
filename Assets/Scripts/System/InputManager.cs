using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]

public class InputManager : Singleton<InputManager>
{
    [SerializeField] private PlayerInput inputs;

    private GameManager manager;
    private InputAction moveAction;

    public UnityEvent interactionEvent;

    void Start()
    {
        inputs = GetComponent<PlayerInput>();
        moveAction = inputs.actions.FindAction("Move");
    }

    public Vector2 GetMovingInputs()
    {
        return moveAction.ReadValue<Vector2>();
    }

    public void OnInteract()
    {
        interactionEvent.Invoke();
    }

}
