using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 3.0f;
    public LayerMask interactableLayer;

    // This is now only used for potential UI feedback, not the core logic.
    private IInteractable currentInteractableForFeedback;

    // OnInteract is now completely self-contained.
    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("E key pressed. Performing interaction check...");
            
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
            {
                IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();
                if (interactable != null)
                {
                    Debug.Log("Found interactable: " + hit.collider.name + ". Calling Interact().");
                    interactable.Interact();
                }
                else
                {
                    Debug.LogWarning("Raycast hit " + hit.collider.name + ", but it has no IInteractable component.");
                }
            }
            else
            {
                Debug.LogWarning("Pressed E but not looking at anything interactable.");
            }
        }
    }

    // The Update loop is now only for visual feedback, like highlighting an object or showing a tooltip.
    // It is no longer involved in the interaction logic itself.
    void Update()
    {
        CheckForInteractableForFeedback();
    }

    void CheckForInteractableForFeedback()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();
            if (currentInteractableForFeedback != interactable)
            {
                currentInteractableForFeedback = interactable;
                if (currentInteractableForFeedback != null)
                {
                    Debug.Log("Now looking at interactable: " + hit.collider.name);
                }
                else
                {
                    Debug.Log("No longer looking at an interactable (object is not interactable).");
                }
            }
        }
        else if (currentInteractableForFeedback != null)
        {
            currentInteractableForFeedback = null;
            Debug.Log("No longer looking at an interactable (looking at empty space).");
        }
    }
}

public interface IInteractable
{
    void Interact();
}