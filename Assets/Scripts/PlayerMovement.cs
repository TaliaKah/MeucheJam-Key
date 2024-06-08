using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput inputs;
    private GameManager manager;
    private InputAction moveAction;

    private Vector2 velocity = Vector2.zero;
    [SerializeField] private float speed = 5f;

    void Start()
    {
        manager = GameManager.Instance;

        inputs = GameManager.Instance.GetInputs();
        moveAction = inputs.actions.FindAction("Move");
    }

    void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        velocity = moveValue * speed;
        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0f);
    }

}
