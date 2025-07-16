using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance { get; private set; }
    public GameObject inventoryPanel;

    // 이전에 추가하셨을 수 있는 태그 관련 코드는 모두 삭제해주세요.
    // 예를 들어 Update()나 다른 함수 안에 FindWithTag("인벤토리 열린다!") 같은 코드가 있다면 지워주세요.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // 주석 처리하거나 필요에 따라 사용
        }
        else
        {
            Destroy(gameObject);
        }

        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    // 이 함수를 새로 추가합니다!
    // 이 함수가 직접 인벤토리를 켜고 끄는 역할을 합니다.
    public void ToggleInventory()
    {
        if (inventoryPanel != null)
        {
            // 현재 인벤토리 패널의 활성화 상태를 가져와서 그 반대로 설정합니다.
            bool isVisible = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isVisible);
        }
        else
        {
            Debug.LogWarning("인벤토리 패널이 InventoryUI 스크립트에 할당되지 않았습니다!");
        }
    }

    // UpdateInventoryVisibility 함수는 그대로 두거나 삭제해도 됩니다.
    // public void UpdateInventoryVisibility(bool isVisible) { ... }
}