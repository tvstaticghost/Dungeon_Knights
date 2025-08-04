using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Start()
    {
        float clipLength = Random.Range(0.42f, 0.47f);
        animator.speed = clipLength;
    }
}
