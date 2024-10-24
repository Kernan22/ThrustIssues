using System.Collections;
using UnityEngine;
using TMPro;         

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  // For TextMeshPro (or use `public Text countdownText;` for UI Text)
    public GameObject gameElements;        // Reference to the game elements (player, environment, etc.)
    
    private void Start()
    {
        // Disable the game elements at the start
        gameElements.SetActive(false);
        
        // Start the countdown coroutine
        StartCoroutine(CountdownToStart());
    }

    private IEnumerator CountdownToStart()
    {
        // Enable the countdown text
        countdownText.enabled = true;

        // Start countdown from 3 to 1
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();  // Update the text to display the current number
            yield return new WaitForSeconds(1f); // Wait for 1 second
        }

        // After the countdown is done, hide the countdown text
        countdownText.enabled = false;

        // Enable game elements (start the game)
        gameElements.SetActive(true);
        
        // Optionally, you can start other game logic here (e.g., start timers, allow player control, etc.)
    }
}
