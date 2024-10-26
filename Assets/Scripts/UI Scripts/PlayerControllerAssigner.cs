using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerAssigner : MonoBehaviour
{
    public PlayerInput player1Input;
    public PlayerInput player2Input;

    void Start()
    {
        // Ensure we have at least 2 controllers connected
        if (Gamepad.all.Count < 2)
        {
            Debug.LogError("Not enough controllers connected!");
            return;
        }

        // Assign the detected gamepads to the players
        // Assuming DualSense (PS5 controller) is Player 1 and Switch Pro Controller is Player 2
        player1Input.SwitchCurrentControlScheme("Player1", Gamepad.all[0]);
        player2Input.SwitchCurrentControlScheme("Player2", Gamepad.all[1]);

        Debug.Log("Player 1 assigned to: " + Gamepad.all[0].name);
        Debug.Log("Player 2 assigned to: " + Gamepad.all[1].name);
    }
}
