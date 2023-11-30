using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 5f; // Adjust this value to control the jump force
    public Rigidbody2D myRigidbody2D;
    private bool isGrounded = false;
    public Animator myAnimator; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            myAnimator.SetBool("isGrounded", isGrounded);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player has left the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            myAnimator.SetBool("isGrounded", isGrounded);
        }
    }

    private void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Apply the jump force only if the player is grounded
            myRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}

