using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GroundDetector groundDetection;

    private object priorityDevice = null;

    private bool isTouchingLadder = false;
    public bool isClimbingLadder = false;

    public void Move(Vector2 direction, object inputDevice)
    {
        SetPriorityInputDevice(direction, inputDevice);
        
        if (IsNotUsingPriorityInputDevice(inputDevice))
            return;
        
        FaceCorrectDirection(direction);
        Animate(direction);
        ApplyMovement(direction);
    }

    public void Jump(object inputDevice)
    {
        //Early return if the player is not touching the ground
        if (!groundDetection.IsGrounded())
            return;
        
        SetPriorityInputDevice(Vector2.zero, inputDevice);
    
        if (IsNotUsingPriorityInputDevice(inputDevice))
            return;
        
        ApplyJump();
    }

    private void ApplyJump()
    {
        rigidbody.AddForce(Vector2.up * GameParameters.PlayerJumpPower, ForceMode2D.Impulse);
    }

    private bool IsNotUsingPriorityInputDevice(object inputDevice)
    {
        return inputDevice != priorityDevice;
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (IsNotFacingTheRightDirection(direction))
        {
            FlipFacingDirection();
        }
    }

    private void FlipFacingDirection()
    {
        transform.localScale = new Vector3(
            transform.localScale.x * -1,
            transform.localScale.y,
            transform.localScale.z);
    }
    
    private bool IsNotFacingTheRightDirection(Vector2 direction)
    {
        float directionCheck = direction.x;
        
        return directionCheck > 0 && transform.localScale.x < 0
               || directionCheck < 0 && transform.localScale.x > 0;
    }

    private void SetPriorityInputDevice(Vector2 direction, object inputDevice)
    {
        if (IsMoving(direction))
        {
            priorityDevice = inputDevice;
        }
    }

    private bool IsMoving(Vector2 direction)
    {
        return direction != Vector2.zero;
    }

    private void ApplyMovement(Vector2 direction)
    {
        //If the player presses W or S when colliding with a ladder, they will enter a climbable ladder state.
        //This state is turned off when the player exits the ladder's collider.
        if (isTouchingLadder && Mathf.Abs(direction.y) > 0)
        {
            isClimbingLadder = true;
        }
        
        if (isClimbingLadder)
        {
            //Make ladder movement slower than regular movement by dividing speed in half
            rigidbody.linearVelocity = direction * (GameParameters.PlayerSpeed / 2);
        }
        else
        {
            rigidbody.linearVelocity = new Vector2(direction.x * GameParameters.PlayerSpeed, rigidbody.linearVelocity.y);
        }
    }

    private void Animate(Vector2 direction)
    {
        animator.SetFloat("Horizontal", Mathf.Abs(direction.x));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isTouchingLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isTouchingLadder = false;
            isClimbingLadder = false;
        }    
    }
}
