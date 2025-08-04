using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float arrowMovementSpeed;
    void Update()
    {
        rb.linearVelocity = arrowMovementSpeed * Vector2.left;
    }
}
