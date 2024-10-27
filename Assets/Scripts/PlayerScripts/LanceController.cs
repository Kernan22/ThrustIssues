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
        playerInput.actions["Move"].performed += OnMovePerformed;
        playerInput.actions["Move"].canceled += OnMovePerformed;
    }

    private void OnDestroy()
    {
        playerInput.actions["Move"].performed -= OnMovePerformed;
        playerInput.actions["Move"].canceled -= OnMovePerformed;
    }

    public void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        MoveLance(input);
    }

    public void MoveLance(Vector2 input)
    {
        if (!isDeflecting)
        {
            float horizontalInput = input.x;
            float verticalInput = input.y;

            currentHorizontalAngle += horizontalInput * rotationSpeed * Time.deltaTime;
            currentVerticalAngle += verticalInput * rotationSpeed * Time.deltaTime;

            currentHorizontalAngle = Mathf.Clamp(currentHorizontalAngle, -maxHorizontalAngle, maxHorizontalAngle);
            currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, -maxVerticalAngle, maxVerticalAngle);

            lowerRightArm.localRotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);
        }
    }

    public void BlockedByShield()
    {
        if (!isDeflecting)
        {
            isDeflecting = true;
            Debug.Log("Lance is deflected by shield!");
            StartCoroutine(DeflectLance());
        }
    }

    public System.Collections.IEnumerator DeflectLance()
    {
        float targetHorizontalAngle = currentHorizontalAngle + deflectionAngle;
        float targetVerticalAngle = currentVerticalAngle + deflectionAngle;

        while (Mathf.Abs(currentHorizontalAngle - targetHorizontalAngle) > 0.1f &&
               Mathf.Abs(currentVerticalAngle - targetVerticalAngle) > 0.1f)
        {
            currentHorizontalAngle = Mathf.Lerp(currentHorizontalAngle, targetHorizontalAngle, Time.deltaTime * deflectionSpeed);
            currentVerticalAngle = Mathf.Lerp(currentVerticalAngle, targetVerticalAngle, Time.deltaTime * deflectionSpeed);

            lowerRightArm.localRotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);
            yield return null;
        }

        isDeflecting = false;
    }

    // Detect collision with the opponent's head
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Log the object we collided with

        // Check if the collision is specifically with the head
        if (collision.gameObject.CompareTag("Head"))
        {
            KnightController knightController = collision.transform.root.GetComponent<KnightController>();

            if (knightController != null)
            {
                knightController.RagdollOnHit();
                Debug.Log("Head hit detected! Ragdoll activated.");
            }
            else
            {
                Debug.LogWarning("KnightController not found on the root of the head object.");
            }
        }
    }
}
