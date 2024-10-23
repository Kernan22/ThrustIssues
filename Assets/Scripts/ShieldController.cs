using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public Transform knightArm; // Reference to the knight's arm transform
    public float movementSpeed = 2f; // Speed of shield movement
    public Vector3 offset; // Offset to position the shield relative to the arm

    private void Start()
    {
        // Set the initial offset based on the current position of the shield
        offset = transform.position - knightArm.position;
    }

    private void Update()
    {
        // Get input for shield movement (replace with your input method)
        Vector2 shieldInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Move shield based on input
        MoveShield(shieldInput);
    }

    public void MoveShield(Vector2 input)
    {
        // Calculate the direction to move the shield: X for horizontal, Y for vertical (up/down)
        Vector3 direction = new Vector3(input.x, input.y, 0); // Swapped Z-axis (forward/backward) with Y-axis (up/down)

        // Calculate the new position for the shield
        Vector3 targetPosition = knightArm.position + offset + direction * movementSpeed * Time.deltaTime;

        // Set the shield's position
        transform.position = targetPosition;

        // Optionally, align the shield's rotation with the knight's arm
        transform.rotation = knightArm.rotation;
    }
}

