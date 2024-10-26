using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerAssigner : MonoBehaviour
{
    public PlayerInput playerInput;  // Reference to PlayerInput component

    private void Start()
    {
        // Make sure PlayerInput component is assigned
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
        }

        // Switch to a specific control scheme if necessary
        if (playerInput != null)
        {
            SwitchControlScheme("Gamepad");  // Replace "Gamepad" with the control scheme name you want to use
        }
    }

    private void SwitchControlScheme(string controlScheme)
    {
        // Get all connected devices of the specified control scheme type
        var devices = InputSystem.devices;

        // Switch the control scheme using the current devices
        playerInput.SwitchCurrentControlScheme(controlScheme, devices.ToArray());
    }
}