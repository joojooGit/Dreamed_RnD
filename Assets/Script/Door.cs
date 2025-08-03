using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen = false;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator != null)
        {
            // This line was the problem and has been removed.
        }
    }

    public void Interact()
    {
        if (animator == null) 
        {
            Debug.LogError("Animator component not found!");
            return;
        }

        isOpen = !isOpen;

        if (isOpen)
        {
            Debug.Log("Opening door.");
            animator.SetFloat("AnimationSpeed", 1.0f);
        }
        else
        {
            Debug.Log("Closing door.");
            animator.SetFloat("AnimationSpeed", -1.0f);
        }
        
        animator.Play(0, -1, isOpen ? 0f : 1f);
    }
}