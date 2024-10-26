using UnityEngine;

public class UpperArmController : MonoBehaviour
{
    public Transform upperRightArm;  // Assign the upper right arm Transform in the Inspector
    public float rotationSpeed = 100f;  // Speed of rotation
    public float maxRotation = 90f;  // Max forward rotation (90 degrees)
    public float minRotation = -90f;  // Max backward rotation (-90 degrees)
    public float stopDelay = 0.1f; // Delay before stopping rotation to avoid conflicts

    private float currentYRotation = 0f;  // The current Y-axis rotation
    private float rotationInput = 0f;  // Holds the input value for rotation
    private float lastInputTime; // Timestamp for the last input

    private void Update()
    {
        // Gradually rotate the arm based on the rotationInput value (-1 for backward, 1 for forward)
        if (Time.time - lastInputTime > stopDelay)
        {
            rotationInput = 0f;
        }

        currentYRotation += rotationInput * rotationSpeed * Time.deltaTime;

        // Clamp the Y-axis rotation to the defined limits
        currentYRotation = Mathf.Clamp(currentYRotation, minRotation, maxRotation);

        // Apply the rotation only to the Y-axis
        upperRightArm.localRotation = Quaternion.Euler(0, currentYRotation, 0);
    }

    public void RotateForward()
    {
        rotationInput = 1f;  // Set input to rotate forward
        lastInputTime = Time.time;
    }

    public void RotateBackward()
    {
        rotationInput = -1f;  // Set input to rotate backward
        lastInputTime = Time.time;
    }

    public void StopRotation()
    {
        lastInputTime = Time.time;  // Update the timestamp when StopRotation is called
    }
}
