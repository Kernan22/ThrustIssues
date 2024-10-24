using UnityEngine;
using UnityEngine.InputSystem;

public class LanceController : MonoBehaviour
{
    public Transform lowerRightArm;  // Assign this to the lower right arm of the knight in the Inspector
    public float rotationSpeed = 100f;
    public float maxVerticalAngle = 45f;
    public float maxHorizontalAngle = 45f;

    private float currentHorizontalAngle = 0f;
    private float currentVerticalAngle = 0f;

    // This method will handle arm movement based on player input
    public void MoveLance(Vector2 input)
    {
        // Separate the input into horizontal and vertical components
        float horizontalInput = input.x;
        float verticalInput = input.y;

        // Update the angles
        currentHorizontalAngle += horizontalInput * rotationSpeed * Time.deltaTime;
        currentVerticalAngle += verticalInput * rotationSpeed * Time.deltaTime;

        // Clamp the angles to prevent unnatural movement
        currentHorizontalAngle = Mathf.Clamp(currentHorizontalAngle, -maxHorizontalAngle, maxHorizontalAngle);
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, -maxVerticalAngle, maxVerticalAngle);

        // Apply the rotation to the lower right arm
        lowerRightArm.localRotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);
    }
}