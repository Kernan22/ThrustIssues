using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, ControllerInput.IControllerActions
{
    public ShieldController shieldController;
    public LanceController lanceController;
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

    // Handle R1 button (upper arm forward rotation)
    public void OnR1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            upperArmController.RotateForward();  // Rotate forward when R1 is pressed
        }
        else if (context.canceled)
        {
            upperArmController.StopRotation();  // Stop rotation when R1 is released
        }
    }

    // Handle R2 button (upper arm backward rotation)
    public void OnR2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            upperArmController.RotateBackward();  // Rotate backward when R2 is pressed
        }
        else if (context.canceled)
        {
            upperArmController.StopRotation();  // Stop rotation when R2 is released
        }
    }
}
