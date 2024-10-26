using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, ControllerInput.IControllerActions
{
    public ShieldController shieldController;  // Reference to ShieldController
    public LanceController lanceController;    // Reference to LanceController
    public UpperArmController upperArmController;  // Reference to UpperArmController

    private ControllerInput inputActions;

    private void Awake()
    {
        inputActions = new ControllerInput();
        inputActions.Controller.SetCallbacks(this);
    }

    private void OnEnable()
    {
        inputActions.Enable();  // Enable input actions
    }

    private void OnDisable()
    {
        inputActions.Disable();  // Disable input actions
    }

    // Handle shield movement with the left stick
    public void OnLeftStickShield(InputAction.CallbackContext context)
    {
        Vector2 shieldInput = context.ReadValue<Vector2>();
        shieldController.MoveShield(shieldInput);  // Pass input to ShieldController
    }

    // Handle lance movement with the right stick
    public void OnRightStickLance(InputAction.CallbackContext context)
    {
        Vector2 lanceInput = context.ReadValue<Vector2>();
        lanceController.MoveLance(lanceInput);  // Pass input to LanceController
    }

    // Handle R1 button (rotate arm backward)
    public void OnR1(InputAction.CallbackContext context)
    {
        if (context.performed) // When R1 is pressed down
        {
            Debug.Log("R1 pressed - Rotating arm backward");
            upperArmController.RotateBackward();
        }
        else if (context.canceled) // When R1 is released
        {
            Debug.Log("R1 released - Stopping arm rotation");
            upperArmController.StopRotation();
        }
    }

    // Handle R2 button (rotate arm forward)
    public void OnR2(InputAction.CallbackContext context)
    {
        if (context.performed) // When R2 is pressed down
        {
            Debug.Log("R2 pressed - Rotating arm forward");
            upperArmController.RotateForward();
        }
        else if (context.canceled) // When R2 is released
        {
            Debug.Log("R2 released - Stopping arm rotation");
            upperArmController.StopRotation();
        }
    }

    // Empty implementation for OnShieldMove to satisfy the interface
    public void OnShieldMove(InputAction.CallbackContext context)
    {
        // Leave empty or add functionality if needed
    }
}
