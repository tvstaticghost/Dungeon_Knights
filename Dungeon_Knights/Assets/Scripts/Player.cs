using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] float movementSpeed;
    private bool walking = false;

    enum Direction { UP, DOWN, LEFT, RIGHT}
    private Direction currentDirection = Direction.RIGHT;

    public void Move(InputAction.CallbackContext context)
    {
        // northeast movement = (0.71, 0.71) -- northwest movement = (-0.71, 0.71) -- southeast movement = (0.71, -0.71) -- southwest movement = (-0.71, -0.71)
        Vector2 val = context.ReadValue<Vector2>();
        Debug.Log(val);

        if (val.x == 1.0)
        {
            walking = true;
            currentDirection = Direction.RIGHT;
            rb.linearVelocity = val * movementSpeed;
        }
        else if (val.x == -1.0)
        {
            walking = true;
            currentDirection = Direction.LEFT;
            rb.linearVelocity = val * movementSpeed;
        }
        else
        {
            walking = false;
            rb.linearVelocity = new Vector2(0f, 0f) * movementSpeed;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.Play("Paladin_Idle_Right");
    }

    private void PlayIdleAnimation()
    {
        switch (currentDirection)
        {
            case Direction.LEFT:
                animator.Play("Paladin_Idle_Left");
                break;
            case Direction.RIGHT:
                animator.Play("Paladin_Idle_Right");
                break;
        }
    }

    private void PlayWalkAnimation()
    {
        switch (currentDirection)
        {
            case Direction.LEFT:
                animator.Play("Paladin_Walk_Left");
                break;
            case Direction.RIGHT:
                animator.Play("Paladin_Walk_Right");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (walking)
        {
            PlayWalkAnimation();
        }
        else
        {
            PlayIdleAnimation();
        }
    }
}
