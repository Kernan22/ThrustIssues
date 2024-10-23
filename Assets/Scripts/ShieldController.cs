using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public Transform shieldTransform;
    public float moveSpeed = 5f;

    public void MoveShield(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x, 0, direction.y) * moveSpeed * Time.deltaTime;
        shieldTransform.localPosition += movement;
    }
}
