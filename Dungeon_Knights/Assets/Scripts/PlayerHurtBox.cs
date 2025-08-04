using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Player Hurt");
        }
    }
}
