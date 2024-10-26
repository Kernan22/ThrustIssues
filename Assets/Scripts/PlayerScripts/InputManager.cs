using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, ControllerInput.IControllerActions
{
    public ShieldController shieldController;  // Reference to the ShieldController script
    public LanceController lanceController;    // Reference to the LanceController script
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

    // Handle shield movement with left stick
    public void OnLeftStickShield(InputAction.CallbackContext context)
    {
        Vector2 shieldInput = context.ReadValue<Vector2>();
        shieldController.MoveShield(shieldInput);  // Pass input to ShieldController
    }

    // Handle lance movement with right stick
    public void OnRightStickLance(InputAction.CallbackContext context)
    {
        Vector2 lanceInput = context.ReadValue<Vector2>();
        lanceController.MoveLance(lanceInput);  // Pass input to LanceController
    }

    // Handle R1 button (start rotating backward)
    public void OnR1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            upperArmController.RotateBackward();  // Start rotating backward when R1 is pressed
        }
        else if (context.canceled)
        {
            upperArmController.StopRotation();  // Stop rotating when R1 is released
        }
    }

    // Handle R2 button (start rotating forward)
    public void OnR2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            upperArmController.RotateForward();  // Start rotating forward when R2 is pressed
        }
        else if (context.canceled)
        {
            upperArmController.StopRotation();  // Stop rotating when R2 is released
        }
    }

    // Implement the missing OnShieldMove method
    public void OnShieldMove(InputAction.CallbackContext context)
    {
        Vector2 shieldInput = context.ReadValue<Vector2>();
        shieldController.MoveShield(shieldInput);  // Pass the input to the ShieldController to move the shield
    }
}
