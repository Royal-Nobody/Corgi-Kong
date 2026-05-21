using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Game game;
    public Rigidbody2D rigidbody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GroundDetector groundDetection;
    public SoundEffects sounds;
    public GameObject flySwatterCollider;

    private object priorityDevice = null;

    private bool canPickupFlaySwatter = true;
    private bool isTouchingLadder = false;
    public bool isJumping = false;
    public bool isClimbingLadder = false;
    public bool hasFlySwatter;
    
    private void Update()
    {
        CheckForSounds();
    }

    public void Move(Vector2 direction, object inputDevice)
    {
        if (!game.isGameActive)
            return;
        
        SetPriorityInputDevice(direction, inputDevice);
        
        if (IsNotUsingPriorityInputDevice(inputDevice))
            return;
        
        FaceCorrectDirection(direction);
        Animate(direction);
        ApplyMovement(direction);
    }

    private void CheckForSounds()
    {
        if (Mathf.Abs(rigidbody.linearVelocityX) > 0.1 && !isClimbingLadder && groundDetection.IsGrounded())
        {
            sounds.PlayJonSound(SoundEffects.JonSoundType.Run, false);
        }
        else
        {
            sounds.StopRunningSound();
        }

        if (isClimbingLadder)
        {
            sounds.PlayJonSound(SoundEffects.JonSoundType.Climb, false);
        }
        else
        {
            sounds.StopClimbingSound();
        }
    }

    public void Jump(object inputDevice)
    {
        if (!game.isGameActive)
            return;
        
        //Early return if the player is not touching the ground
        if (!groundDetection.IsGrounded())
            return;
        
        SetPriorityInputDevice(Vector2.zero, inputDevice);
    
        if (IsNotUsingPriorityInputDevice(inputDevice))
            return;

        sounds.PlayJonSound(SoundEffects.JonSoundType.Jump, false);
        isJumping = true;
        StartCoroutine(CheckIfJumpingStill());
        ApplyJump();
    }

    private void EquipFlySwatter(GameObject swatter)
    {
        hasFlySwatter = true;
        canPickupFlaySwatter = false;
        swatter.SetActive(false);
        flySwatterCollider.SetActive(true);
        
        StartCoroutine(FlySwatterLifeCycle());
    }

    IEnumerator FlySwatterLifeCycle()
    {
        yield return new WaitForSeconds(GameParameters.FlySwatterEquipTimeSeconds);
        UnequipFlySwatter();
    }

    private void UnequipFlySwatter()
    {
        hasFlySwatter = false;
        canPickupFlaySwatter = true;
        flySwatterCollider.SetActive(false);
    }
    
    private void ApplyJump()
    {
        rigidbody.AddForce(Vector2.up * GameParameters.PlayerJumpPower, ForceMode2D.Impulse);
    }

    IEnumerator CheckIfJumpingStill()
    {
        yield return new WaitForSeconds(0.5f);
        while (isJumping)
        {
            if (groundDetection.IsGrounded())
            {
                isJumping = false;
            }

            yield return null;
        }
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
        if (IsMovingInThisDirection(direction))
        {
            priorityDevice = inputDevice;
        }
    }

    private bool IsMovingInThisDirection(Vector2 direction)
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
            DisableLadderPlatformCollisions();
            
            //Make ladder movement slower than regular movement by dividing speed in half
            rigidbody.linearVelocity = direction * (GameParameters.PlayerSpeed / 2);
        }
        else
        {
            RestoreLadderPlatformCollisions();
            
            rigidbody.linearVelocity = new Vector2(direction.x * GameParameters.PlayerSpeed, rigidbody.linearVelocity.y);
        }
    }

    private void Animate(Vector2 direction)
    {
        animator.SetFloat("Horizontal", Mathf.Abs(direction.x));
        animator.SetBool("IsClimbing", isClimbingLadder);
        animator.SetBool("IsJumping", isJumping);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isTouchingLadder = true;
        }

        if (other.CompareTag("FlySwatter"))
        {
            if (canPickupFlaySwatter)
            {
                EquipFlySwatter(other.gameObject);
            }
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
    
    private void DisableLadderPlatformCollisions()
    {
        GameObject[] ladderPlatformColliders = GameObject.FindGameObjectsWithTag("Effector");

        foreach (GameObject ladderPlatformCollider in ladderPlatformColliders)
        {
            Collider2D collider = ladderPlatformCollider.GetComponentInChildren<Collider2D>();
            Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
        }
    }
    
    private void RestoreLadderPlatformCollisions()
    {
        GameObject[] ladderPlatformColliders = GameObject.FindGameObjectsWithTag("Effector");

        foreach (GameObject ladderPlatformCollider in ladderPlatformColliders)
        {
            Collider2D collider = ladderPlatformCollider.GetComponentInChildren<Collider2D>();
            Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), false);
        }
    }

    public void TurnOffStateMachines()
    {
        isClimbingLadder = false;
        isJumping = false;
        isTouchingLadder = false;
    }
}
