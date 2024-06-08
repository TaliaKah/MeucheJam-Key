using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput inputs;
    private GameManager manager;
    private InputAction moveAction;

    private Animator animation;

    private Vector2 velocity = Vector2.zero;
    private int direction = 0;
    [SerializeField] private float speed = 5f;

    void Start()
    {
        manager = GameManager.Instance;
        animation = GetComponent<Animator>();

        inputs = GameManager.Instance.GetInputs();
        moveAction = inputs.actions.FindAction("Move");
    }

    void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        moveValue = ChooseDirection(moveValue);

        velocity = moveValue * speed;
        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0f);

        //Animation
        animation.SetInteger("direction", direction);
    }

    private Vector2 ChooseDirection(Vector2 value)
    {
        Vector2 result = Vector2.zero;
        if(Mathf.Abs(value.x) >= Mathf.Abs(value.y))
        {
                result = new Vector2(value.x, 0);
        }
        else
        {
            result = new Vector2(0, value.y);
        }
        direction = SetDirection(result);
        return result;
    }

    private int SetDirection(Vector2 vector)
    {
        if (vector.x > 0)
        {
            return 6;
        }
        if (vector.x < 0)
        {
            return 4;
        }
        if (vector.y > 0)
        {
            return 8;
        }
        if (vector.y < 0)
        {
            return 2;
        }
        return 0;
    } 

}
