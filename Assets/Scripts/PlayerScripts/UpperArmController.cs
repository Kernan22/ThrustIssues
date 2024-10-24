using UnityEngine;

public class UpperArmController : MonoBehaviour
{
    public Transform upperRightArm;  // Assign the upper right arm Transform in the Inspector
    public float rotationSpeed = 100f;  // Speed of rotation
    private float targetYRotation = 0f;  // The target Y-axis rotation
    private float currentYRotation = 0f;  // The current Y-axis rotation
    private float maxRotation = 90f;  // Max forward rotation (90 degrees)
    private float minRotation = -90f;  // Max backward rotation (-90 degrees)

    private void Update()
    {
        // Smoothly rotate towards the target rotation along the Y-axis
        currentYRotation = Mathf.Lerp(currentYRotation, targetYRotation, rotationSpeed * Time.deltaTime);

        // Apply the rotation only to the Y-axis
        upperRightArm.localRotation = Quaternion.Euler(0, currentYRotation, 0);
    }

    // Rotate the arm forward (R1)
    public void RotateForward()
    {
        targetYRotation = maxRotation;  // Set target to max forward rotation (90 degrees)
    }

    // Rotate the arm backward (R2)
    public void RotateBackward()
    {
        targetYRotation = minRotation;  // Set target to max backward rotation (-90 degrees)
    }

    // Stop rotation (when R1 or R2 is released)
    public void StopRotation()
    {
        // Optionally set to neutral (0 degrees) or keep the current position
        // targetYRotation = 0f;  // Uncomment this line to return to neutral position if desired
    }
}