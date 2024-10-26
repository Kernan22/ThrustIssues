using UnityEngine;
using UnityEngine.InputSystem;

public class LanceController : MonoBehaviour
{
    public Transform lowerRightArm;  // Assign this to the lower right arm of the knight in the Inspector
    public float rotationSpeed = 100f;
    public float maxVerticalAngle = 45f;
    public float maxHorizontalAngle = 45f;
    public float deflectionAngle = 20f;  // Angle to deflect on shield block
    public float deflectionSpeed = 2f;   // Speed of deflection

    private float currentHorizontalAngle = 0f;
    private float currentVerticalAngle = 0f;
    private bool isDeflecting = false;  // Track if the lance is currently deflecting

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        // Subscribe to the "Move" action
        playerInput.actions["Move"].performed += OnMovePerformed;
        playerInput.actions["Move"].canceled += OnMovePerformed; // Stop movement when canceled
    }

    public void OnDestroy()
    {
        // Unsubscribe when object is destroyed
        playerInput.actions["Move"].performed -= OnMovePerformed;
        playerInput.actions["Move"].canceled -= OnMovePerformed;
    }

    public void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        MoveLance(input);
    }

    // This method will handle arm movement based on player input
    public void MoveLance(Vector2 input)
    {
        // Only allow movement if the lance is not deflecting
        if (!isDeflecting)
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

    // Call this method when the shield blocks the spear
    public void BlockedByShield()
    {
        if (!isDeflecting)  // Ensure we only deflect once per collision
        {
            isDeflecting = true;
            Debug.Log("Lance is deflected by shield!");
            StartCoroutine(DeflectLance());
        }
    }

    // Coroutine to handle the deflection effect
    public System.Collections.IEnumerator DeflectLance()
    {
        // Apply a quick deflection angle
        float targetHorizontalAngle = currentHorizontalAngle + deflectionAngle;
        float targetVerticalAngle = currentVerticalAngle + deflectionAngle;

        // Smoothly rotate towards the deflection angle
        while (Mathf.Abs(currentHorizontalAngle - targetHorizontalAngle) > 0.1f &&
               Mathf.Abs(currentVerticalAngle - targetVerticalAngle) > 0.1f)
        {
            currentHorizontalAngle = Mathf.Lerp(currentHorizontalAngle, targetHorizontalAngle, Time.deltaTime * deflectionSpeed);
            currentVerticalAngle = Mathf.Lerp(currentVerticalAngle, targetVerticalAngle, Time.deltaTime * deflectionSpeed);

            lowerRightArm.localRotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);
            yield return null;
        }

        // Return to normal state after deflection
        isDeflecting = false;
    }
}
