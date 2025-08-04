using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
        }
    }
}
