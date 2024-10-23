using UnityEngine;

public class LanceController : MonoBehaviour
{
    public Transform spearTip; // Assign the spear's tip Transform in the Inspector
    public Transform lowerArm; // Assign the lower arm Transform in the Inspector
    public float speed = 1f; // Adjust this for how fast you want the spear to move

    public void MoveLance(Vector2 input)
    {
        // Calculate the new position for the spear's tip based on input
        Vector3 newTipPosition = spearTip.position + new Vector3(input.x, 0, input.y) * speed * Time.deltaTime;

        // Set the new position of the spear's tip
        spearTip.position = newTipPosition;

        // Optional: Rotate the lower arm to face the spear tip
        Vector3 direction = (spearTip.position - lowerArm.position).normalized;
        lowerArm.rotation = Quaternion.LookRotation(direction);
    }
}