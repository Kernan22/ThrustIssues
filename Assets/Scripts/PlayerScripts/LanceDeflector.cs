using UnityEngine;

public class LanceDeflector : MonoBehaviour
{
    [SerializeField] private float bounceDistance = 0.2f; // Distance to move the lance back
    [SerializeField] private float bounceDuration = 0.1f; // Duration of the bounce effect
    private Transform lanceTransform; // Reference to the lance transform
    private Vector3 originalPosition; // Original position of the lance

    private void Start()
    {
        // Find the lance object by tag (assuming there's only one with this tag in the scene)
        lanceTransform = GameObject.FindWithTag("Lance").transform;
        // Store the original position
        originalPosition = lanceTransform.localPosition;
    }

   private void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.CompareTag("Lance"))
       {
           Debug.Log("Lance collided with shield!"); // Check if this message appears
           StartCoroutine(BounceBack());
       }
       else
       {
           Debug.Log("Collision detected but not with lance: " + collision.gameObject.name);
       }
   }

    private System.Collections.IEnumerator BounceBack()
    {
        // Calculate the bounce back position
        Vector3 bounceBackPosition = originalPosition - lanceTransform.forward * bounceDistance;

        // Move to the bounce back position
        float elapsedTime = 0f;
        while (elapsedTime < bounceDuration)
        {
            lanceTransform.localPosition = Vector3.Lerp(originalPosition, bounceBackPosition, elapsedTime / bounceDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Hold the bounced back position briefly
        yield return new WaitForSeconds(0.05f);

        // Return the lance to its original position
        elapsedTime = 0f;
        while (elapsedTime < bounceDuration)
        {
            lanceTransform.localPosition = Vector3.Lerp(bounceBackPosition, originalPosition, elapsedTime / bounceDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset exactly to the original position
        lanceTransform.localPosition = originalPosition;
    }
}
