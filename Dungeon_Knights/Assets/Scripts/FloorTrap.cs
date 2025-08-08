using System.Collections;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteImage;
    [SerializeField] Sprite unpressedTile;
    [SerializeField] Sprite pressedTile;
    [SerializeField] GameObject arrow;

    private bool canTriggerTrap = true;
    private float triggerTimer = 0f;
    private float arrowTimer = 1f;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (canTriggerTrap)
            {
                spriteImage.sprite = pressedTile;
                TriggerArrows();
                canTriggerTrap = false;
                triggerTimer = 5f;
            }
        }
    }

    void Update()
    {
        if (triggerTimer > 0f)
        {
            triggerTimer -= Time.deltaTime;
        }
        else
        {
            canTriggerTrap = true;
            spriteImage.sprite = unpressedTile;
        }
    }

    private void SpawnArrow()
    {
        //Need to fix this hardcoded position bullshit
        Instantiate(arrow, new Vector3(8.8f, 0.78f, 0f), Quaternion.identity);
    }

    private void TriggerArrows()
    {
        SpawnArrow();
        StartCoroutine(FireSecondArrow(arrowTimer));
    }

    IEnumerator FireSecondArrow(float arrowTimer)
    {
        yield return new WaitForSeconds(arrowTimer);
        SpawnArrow();
    }
}
