using UnityEngine;

public class KnightController : MonoBehaviour
{
    public Animator animator; 
    public Rigidbody[] ragdollRigidbodies; // Rigidbody components of the knight's ragdoll
    public Collider[] ragdollColliders; // Collider components of the knight's ragdoll

    void Start()
    {
        // Automatically gather all Rigidbody and Collider components in child objects
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();

        // Keep the ragdoll parts inactive at the start
        SetRagdollState(false);
    }

    public void SetRagdollState(bool state)
    {
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            // Enable physics when ragdolling, disable otherwise
            rb.isKinematic = !state; 
        }
        
        foreach (Collider col in ragdollColliders)
        {
            // Enable colliders only when ragdolling
            col.enabled = state; 
        }

        // Enable/disable the Animator depending on the ragdoll state
        if (animator != null)
        {
            animator.enabled = !state;
        }
    }

    // Call this function when the knight gets hit
    public void RagdollOnHit()
    {
        SetRagdollState(true);
    }
}