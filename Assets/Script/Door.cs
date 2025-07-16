using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    public float openAngle = 90.0f;

    // InteractionController가 호출할 함수
    public void Interact()
    {
        isOpen = !isOpen; // 상태를 반전시킵니다 (열림 <-> 닫힘)

        if (isOpen)
        {
            // 문을 엽니다. (Y축 기준으로 90도 회전)
            transform.Rotate(Vector3.up, openAngle);
            Debug.Log("문이 열렸습니다.");
        }
        else
        {
            // 문을 닫습니다. (원래 각도로 되돌림)
            transform.Rotate(Vector3.up, -openAngle);
            Debug.Log("문이 닫혔습니다.");
        }
    }
}