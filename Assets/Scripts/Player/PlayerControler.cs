using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;
    public static PlayerControler Instance;
    private Vector2 movementDirection;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        rigidbody.linearVelocity = movementDirection.normalized * speed;
    }

    void OnMove(InputValue value)
    {

        movementDirection = value.Get<Vector2>();

    }
}
