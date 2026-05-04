using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = GameParameters.PlayerSpeed;
    
    public Rigidbody2D rigidbody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private object priorityDevice = null;

    public void Move(Vector2 direction, object inputDevice)
    {
        SetPriorityInputDevice(direction, inputDevice);
        
        if (IsNotUsingPriorityInputDevice(inputDevice))
            return;
        
        FaceCorrectDirection(direction);
        Animate(direction);
        ApplyMovement(direction);
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
        return direction.x > 0 && transform.localScale.x < 0
               || direction.x < 0 && transform.localScale.x > 0;
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
        rigidbody.linearVelocity = direction * speed;
    }

    private void Animate(Vector2 direction)
    {
        animator.SetFloat("Horizontal", Mathf.Abs(direction.x));
        animator.SetFloat("Vertical", Mathf.Abs(direction.y));
    }
}
