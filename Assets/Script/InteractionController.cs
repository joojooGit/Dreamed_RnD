using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 3.0f;
    public LayerMask interactableLayer; // 상호작용 가능한 오브젝트의 레이어

    private IInteractable currentInteractable; // 현재 감지된 상호작용 가능 오브젝트

    void Update()
    {

        Ray rayForDebug = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(rayForDebug.origin, rayForDebug.direction * interactionDistance, Color.red);

        CheckForInteractable();
    }

    void CheckForInteractable()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            // 광선이 Interactable 레이어의 무언가에 맞았을 때
            Debug.Log("광선이 맞은 물체: " + hit.collider.name); // 맞은 물체 이름 출력

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                // IInteractable 스크립트를 가지고 있을 때
                Debug.Log(hit.collider.name + "에서 상호작용 스크립트 발견!");
                currentInteractable = interactable;
            }
            else
            {
                // IInteractable 스크립트가 없을 때
                Debug.Log(hit.collider.name + "에는 상호작용 스크립트가 없음!");
                currentInteractable = null;
            }
        }
        else
        {
            // 광선에 아무것도 맞지 않았을 때
            currentInteractable = null;
        }
    }

    // Input Action 에 연결될 함수
    public void OnInteract(InputValue value)
    {
        // ▼▼▼ 이 코드가 있는지 확인! ▼▼▼
        Debug.Log("E 키 입력 감지!");

        if (value.isPressed && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
    public void PerformInteraction()
    {
        // 새로운 디버그 메시지로 함수 호출이 성공했는지 확인합니다.
        Debug.Log("PerformInteraction 함수 호출 성공!");

        // 현재 바라보고 있는 상호작용 가능한 오브젝트가 있다면, 상호작용을 실행합니다.
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
}

// 상호작용 인터페이스 정의
public interface IInteractable
{
    void Interact();
}