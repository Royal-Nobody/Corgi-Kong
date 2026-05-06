using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private bool isGrounded;

    public bool IsGrounded()
    {
        return isGrounded;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        
    }
}
