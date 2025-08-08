using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] float movementSpeed;
    [SerializeField] AnimationClip attackClip;
    private bool walking = false;
    private bool attacking = false;
    private bool canAttack = true;

    enum Direction { UP, DOWN, LEFT, RIGHT}
    private Direction currentDirection = Direction.RIGHT;

    public void Move(InputAction.CallbackContext context)
    {
        // northeast movement = (0.71, 0.71) -- northwest movement = (-0.71, 0.71) -- southeast movement = (0.71, -0.71) -- southwest movement = (-0.71, -0.71)
        Vector2 val = context.ReadValue<Vector2>();

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
        else if (val.y == 1.0)
        {
            walking = true;
            currentDirection = Direction.UP;
            rb.linearVelocity = val * movementSpeed;
        }
        else if (val.y == -1.0)
        {
            walking = true;
            currentDirection = Direction.DOWN;
            rb.linearVelocity = val * movementSpeed;
        }
        else
        {
            walking = false;
            rb.linearVelocity = new Vector2(0f, 0f) * movementSpeed;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started && canAttack && !attacking)
        {
            canAttack = false;
            attacking = true;

            PlayAttackAnimation();
            StartCoroutine(AttackTimer(attackClip.length));
        }
    }

    void Start()
    {
        animator.Play("Paladin_Idle_Right");
    }

    private void PlayIdleAnimation()
    {
        switch (currentDirection)
        {
            case Direction.LEFT:
                animator.Play("Idle_West");
                break;
            case Direction.RIGHT:
                animator.Play("Idle_East");
                break;
            case Direction.UP:
                animator.Play("Idle_North");
                break;
        }
    }

    private void PlayWalkAnimation()
    {
        switch (currentDirection)
        {
            case Direction.LEFT:
                animator.Play("Walk_West");
                break;
            case Direction.RIGHT:
                animator.Play("Walk_East");
                break;
            case Direction.UP:
                animator.Play("Walk_North");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            return;
        }

        if (walking)
        {
            PlayWalkAnimation();
        }
        else
        {
            PlayIdleAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        //Fill this function out as I add directional attack animations
        switch (currentDirection)
        {
            case Direction.LEFT:
                animator.Play("Attack_West");
                break;
            case Direction.RIGHT:
                animator.Play("Attack_East");
                break;
        }

        StartCoroutine(AttackTimer(attackClip.length));
    }

    private IEnumerator AttackTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        attacking = false;
        canAttack = true;
    }
}
