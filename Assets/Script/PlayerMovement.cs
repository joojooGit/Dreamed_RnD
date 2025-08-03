
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private Vector2 moveInput;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
