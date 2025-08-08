using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Player Hurt");
        }
        else if (collision.CompareTag("Arrow"))
        {
            Debug.Log("Arrow Hit Player");
            Destroy(collision.gameObject);
        }
    }
}
