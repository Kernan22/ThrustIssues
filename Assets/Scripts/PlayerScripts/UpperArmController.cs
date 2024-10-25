using UnityEngine;

public class UpperArmController : MonoBehaviour
{
    public Transform upperRightArm;  // Assign the upper right arm Transform in the Inspector
    public float rotationSpeed = 100f;  // Speed of rotation
    public float maxRotation = 90f;  // Max forward rotation (90 degrees)
    public float minRotation = -90f;  // Max backward rotation (-90 degrees)

    private float currentYRotation = 0f;  // The current Y-axis rotation
    private float rotationInput = 0f;  // Holds the input value for rotation

    private void Update()
    {
        // Gradually rotate the arm based on the rotationInput value (-1 for backward, 1 for forward)
        currentYRotation += rotationInput * rotationSpeed * Time.deltaTime;

        // Clamp the Y-axis rotation to the defined limits
        currentYRotation = Mathf.Clamp(currentYRotation, minRotation, maxRotation);

        // Apply the rotation only to the Y-axis
        upperRightArm.localRotation = Quaternion.Euler(0, currentYRotation, 0);
    }

    // Method to set input when rotating forward (R1 pressed)
    public void RotateForward()
    {
        rotationInput = 1f;  // Set input to rotate forward
    }

    // Method to set input when rotating backward (R2 pressed)
    public void RotateBackward()
    {
        rotationInput = -1f;  // Set input to rotate backward
    }

    // Stop rotation when neither R1 nor R2 is pressed
    public void StopRotation()
    {
        rotationInput = 0f;  // Stop rotating
    }
}
