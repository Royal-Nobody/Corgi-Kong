using System;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public MovementDirection startingMoveDirection;
    
    private Rigidbody2D rigidbody;

    private Vector2 movementDirectionVector;
    private MovementDirection currentMoveDirection;
    
    public enum MovementDirection
    {
        Up,
        Left,
        Right,
        Down
    }

    private void Start()
    {
        currentMoveDirection = startingMoveDirection;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void FindMovementDirection()
    {
        switch (currentMoveDirection)
        {
            case MovementDirection.Up:
                movementDirectionVector = Vector2.up;
                break;
            case MovementDirection.Left:
                movementDirectionVector = Vector2.left;
                break;
            case MovementDirection.Right:
                movementDirectionVector = Vector2.right;
                break;
            case MovementDirection.Down:
                movementDirectionVector = Vector2.down;
                break;
        }
    }
    
    void Move()
    {
        FindMovementDirection();
        rigidbody.linearVelocity = movementDirectionVector * GameParameters.spiderSpeed;
    }

    public void SwitchDirection(MovementDirection desiredDirection)
    {
        currentMoveDirection = desiredDirection;
    }
}