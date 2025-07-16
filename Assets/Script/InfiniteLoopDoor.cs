using UnityEngine;

public class InfiniteLoopDoor : MonoBehaviour
{
    // 유니티 에디터에서 드래그 앤 드롭으로 연결할 변수들
    public Transform teleportTarget; // 플레이어가 이동될 목표 위치
    public GameObject realExit;      // 퀘스트 완료 후 활성화될 실제 출구 (선택 사항)

    // 게임의 다른 곳에서 이 변수를 true로 바꿔 퀘스트 완료를 알림
    public static bool isQuestCompleted = false;

    private void OnTriggerEnter(Collider other)
    {
        // 트리거에 들어온 오브젝트가 'Player' 태그를 가지고 있는지 확인
        if (other.CompareTag("Player"))
        {
            // 퀘스트가 아직 완료되지 않았다면
            if (!isQuestCompleted)
            {
                Debug.Log("Quest not completed. Teleporting back...");
                // 플레이어를 지정된 위치로 즉시 이동시킵니다.
                other.transform.position = teleportTarget.position;
            }
            else
            {
                // 퀘스트가 완료되었다면
                Debug.Log("Quest completed! The loop is broken.");
                // (선택 사항) 진짜 출구를 활성화하거나 다른 이벤트를 발생시킴
                if (realExit != null)
                {
                    realExit.SetActive(true);
                }
                // 이 문은 더 이상 작동하지 않도록 비활성화
                gameObject.SetActive(false);
            }
        }
    }
}