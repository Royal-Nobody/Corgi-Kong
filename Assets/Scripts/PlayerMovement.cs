using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = GameParameters.PlayerSpeed;
    public float jumpPower = GameParameters.PlayerJumpPower;
    
    public Rigidbody2D rigidbody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private object priorityDevice = null;
    
    public void Move(float direction, object inputDevice)
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
        SetPriorityInputDevice(0f, inputDevice);
    
        if (IsNotUsingPriorityInputDevice(inputDevice))
            return;
        
        ApplyJump();
    }

    private void ApplyJump()
    {
        rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private bool IsNotUsingPriorityInputDevice(object inputDevice)
    {
        return inputDevice != priorityDevice;
    }

    private void FaceCorrectDirection(float direction)
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
    
    private bool IsNotFacingTheRightDirection(float direction)
    {
        return direction > 0 && transform.localScale.x < 0
               || direction < 0 && transform.localScale.x > 0;
    }

    private void SetPriorityInputDevice(float direction, object inputDevice)
    {
        if (IsMoving(direction))
        {
            priorityDevice = inputDevice;
        }
    }

    private bool IsMoving(float direction)
    {
        return direction != 0f;
    }

    private void ApplyMovement(float direction)
    {
        rigidbody.linearVelocity = new Vector2(direction * speed, rigidbody.linearVelocity.y);
    }

    private void Animate(float direction)
    {
        animator.SetFloat("Horizontal", Mathf.Abs(direction));
    }
}
