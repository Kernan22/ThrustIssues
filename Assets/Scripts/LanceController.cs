using UnityEngine;

public class LanceController : MonoBehaviour
{
    public Transform lanceTip; // Assign the tip of the lance in the Inspector
    public Transform lowerArm;  // Assign the lower arm's transform

    private void Update()
    {
        // Optional: Update lance position if needed
    }

    public void MoveLance(Vector2 lanceInput)
    {
        // Make sure the lanceTip is assigned and move it based on input
        if (lanceTip != null)
        {
            // Calculate new position based on input
            Vector3 newPosition = lanceTip.position + new Vector3(lanceInput.x, lanceInput.y, 0f); // Adjust if necessary
            lanceTip.position = newPosition;

            // Optionally, you can rotate or adjust the lance here
        }
    }
}