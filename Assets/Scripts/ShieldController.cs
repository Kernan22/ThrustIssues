using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public Transform knightArm; // Reference to the knight's arm transform
    public float movementSpeed = 2f; // Speed of shield movement
    public float returnSpeed = 5f;   // Speed at which the shield returns to the relative offset position
    public float inputDeadZone = 0.1f; // Dead zone threshold to ignore small stick movements
    public Vector3 offset; // Offset to position the shield relative to the arm

    // Positional limits for clamping
    public float maxHorizontalOffset = 1f; // Maximum horizontal movement range (left-right)
    public float minHorizontalOffset = -1f; // Minimum horizontal movement range
    public float maxVerticalOffset = 1f;    // Maximum vertical movement range (up-down)
    public float minVerticalOffset = -1f;   // Minimum vertical movement range

    private Vector3 initialOffset; // Store the original position relative to the knight's arm

    private void Start()
    {
        // Store the initial offset from the knight arm in world space
        initialOffset = transform.position - knightArm.position;
    }

    private void Update()
    {
        // Get input for shield movement
        Vector2 shieldInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (shieldInput.magnitude > inputDeadZone)
        {
            // Move shield based on input
            MoveShield(shieldInput);
        }
        else
        {
            // If there's no input, return it to the starting position
            ReturnToInitialOffset();
        }
    }

    public void MoveShield(Vector2 input)
    {
        // Calculate the movement direction based on input (X for horizontal, Y for vertical)
        Vector3 direction = new Vector3(input.x, input.y, 0);

        // Calculate the new position by moving relative to the knight's arm
        Vector3 targetPosition = knightArm.position + initialOffset + direction * movementSpeed * Time.deltaTime;

        // Clamp the position to stay within the allowed horizontal and vertical limits
        targetPosition.x = Mathf.Clamp(targetPosition.x, knightArm.position.x + minHorizontalOffset, knightArm.position.x + maxHorizontalOffset);
        targetPosition.y = Mathf.Clamp(targetPosition.y, knightArm.position.y + minVerticalOffset, knightArm.position.y + maxVerticalOffset);

        // Directly move the transform (no Rigidbody)
        transform.position = targetPosition;

        // Optionally, align the shield's rotation with the knight's arm
        transform.rotation = knightArm.rotation;
    }

    public void ReturnToInitialOffset()
    {
        // Smoothly return the shield to its initial position relative to the knight's arm
        Vector3 targetPosition = knightArm.position + initialOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, returnSpeed * Time.deltaTime);
    }
}

