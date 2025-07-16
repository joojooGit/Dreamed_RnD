using UnityEngine;
using UnityEngine.InputSystem;

public class TestMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -9.81f;
    public CharacterController controller;

    private Vector3 velocity;
    private Vector2 moveInput;

    void Update()
    {
        // 중력 적용
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;

        // 이동 계산
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);

        // 최종 이동 적용 (중력 포함)
        controller.Move(velocity * Time.deltaTime);
    }

    // Input Action 에 연결될 함수
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}