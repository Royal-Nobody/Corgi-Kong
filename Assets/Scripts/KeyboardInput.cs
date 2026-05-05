using UnityEngine;
using UnityEngine.InputSystem;

// This script handles all keyboard input for the player
// It uses WASD keys for movement and other keys for actions
//
// SETUP: Drag this component onto your player object.
//        In the Inspector, drag your player's PlayerMovement component into the
//        "Player Movement" slot below.  And the PlayerCombat component into
//        its slot.  That's it!.
public class KeyboardInput : MonoBehaviour
{
    // Drag the PlayerMovement component here in the Inspector
    public PlayerMovement PlayerMovement;

    private void Update()
    {
        // If no PlayerMovement is wired up, skip everything
        if (PlayerMovement == null)
        {
            return;
        }

        // Read the movement direction from WASD keys
        float movement = GetHorizontalMovement();

        // Tell PlayerMovement to move in that direction
        // Always call Move(), even when movement is zero. This is what stops the player
        // when no input is pressed. If we skip Move() on zero, the player keeps drifting.
        PlayerMovement.Move(movement, this);
        
        if (WasJumpButtonPressed())
        {
            PlayerMovement.Jump(this);
        }
    }

    // Gets the movement input from the keyboard as a Vector2 (x and y direction)
    public float GetHorizontalMovement()
    {
        // If no keyboard is available, return no movement
        if (IsKeyboardUnavailable())
        {
            return 0f;
        }

        // Get horizontal movement from A and D keys (-1 for left, 1 for right, 0 for neither)
        float horizontalInput = GetHorizontalInput();
        
        // Combine horizontal and vertical into a Vector2
        // For example: pressing D and W gives Vector2(1, 1) - moving right and up
        float movement = horizontalInput;

        // Return the final movement vector
        return movement;
    }

    // Checks if the place button (E key) was pressed
    public bool WasPlaceButtonPressed()
    {
        // If no keyboard is available, return false
        if (IsKeyboardUnavailable())
        {
            return false;
        }
        
        // Check if E key was pressed THIS frame (not held from previous frames)
        // wasPressedThisFrame only returns true once per key press
        return Keyboard.current[GameParameters.PlaceKey].wasPressedThisFrame;
    }
    
    // Checks if the place button (Space key) was pressed
    public bool WasJumpButtonPressed()
    {
        // If no keyboard is available, return false
        if (IsKeyboardUnavailable())
        {
            return false;
        }
        
        // Check if Space key was pressed THIS frame (not held from previous frames)
        // wasPressedThisFrame only returns true once per key press
        return Keyboard.current[GameParameters.JumpKey].wasPressedThisFrame;
    }

    // Checks if the pickup button (F key) was pressed
    public bool WasPickupButtonPressed()
    {
        // If no keyboard is available, return false
        if (IsKeyboardUnavailable())
        {
            return false;
        }
        
        // Check if F key was pressed THIS frame (not held from previous frames)
        // wasPressedThisFrame only returns true once per key press
        return Keyboard.current[GameParameters.PickupKey].wasPressedThisFrame;
    }

    // Checks if the keyboard is unavailable (not connected or not working)
    private bool IsKeyboardUnavailable()
    {
        // Keyboard.current is null if no keyboard is detected
        // This can happen on some platforms or in certain situations
        return Keyboard.current == null;
    }

    // Gets horizontal input from A and D keys
    // Returns -1 for left (A), 1 for right (D), or 0 for neither/both
    private float GetHorizontalInput()
    {
        // Start with no horizontal movement
        float horizontal = 0f;
        
        // If A key (left) is pressed, subtract 1 (move left)
        if (IsLeftKeyPressed())
        {
            horizontal = horizontal - 1f;
        }
        
        // If D key (right) is pressed, add 1 (move right)
        if (IsRightKeyPressed())
        {
            horizontal = horizontal + 1f;
        }
        
        // Return the final horizontal value
        // Note: If both A and D are pressed, they cancel out to 0
        return horizontal;
    }

    private bool IsLeftKeyPressed()
    {
        return Keyboard.current[GameParameters.MoveLeft].isPressed;
    }

    private bool IsRightKeyPressed()
    {
        return Keyboard.current[GameParameters.MoveRight].isPressed;
    }
}