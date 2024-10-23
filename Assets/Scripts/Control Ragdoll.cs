using UnityEngine;

public class KnightController : MonoBehaviour
{
    public Animator animator; 
    public Rigidbody[] ragdollRigidbodies; // Rigidbody components of the knight's ragdoll
    public Collider[] ragdollColliders; // Collider components of the knight's ragdoll

    void Start()
    {
        // keep the ragdoll parts inactive
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
        animator.enabled = !state;
    }

    // Call this function when the knight gets hit
    public void RagdollOnHit()
    {
        SetRagdollState(true);
    }
}