using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public Transform playerBody; // Player 오브젝트를 연결
    public Transform cameraTransform; // Main Camera 를 연결

    private float xRotation = 0f;
    private Vector2 lookInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 고정
    }

    void Update()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 상하 시점 제한

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }
}