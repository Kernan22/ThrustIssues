using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, ControllerInput.IControllerActions
{
    public ShieldController shieldController;
    public LanceController lanceController;

    private ControllerInput inputActions;

    private void Awake()
    {
        inputActions = new ControllerInput();
        inputActions.Controller.SetCallbacks(this);
    }

    private void OnEnable()
    {
        inputActions.Enable(); // Enable input actions
    }

    private void OnDisable()
    {
        inputActions.Disable(); // Disable input actions
    }

    public void OnLeftStickShield(InputAction.CallbackContext context)
    {
        Vector2 shieldInput = context.ReadValue<Vector2>();
        shieldController.MoveShield(shieldInput); // Pass input to ShieldController
    }

    public void OnRightStickLance(InputAction.CallbackContext context)
    {
        Vector2 lanceInput = context.ReadValue<Vector2>();
        lanceController.MoveLance(lanceInput); // Pass input to LanceController
    }
}