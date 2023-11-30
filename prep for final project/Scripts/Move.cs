using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control the speed of movement
    public Rigidbody2D myRigidbody2D;
    public float horizontalForce = 10f; // Adjust this value to control the force applied horizontally.

    public SpriteRenderer mySpriteRenderer;

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }

        // Calculate the force based on the input and speed
        Vector2 force = new Vector2(horizontalInput * horizontalForce, myRigidbody2D.velocity.y);

        // Apply the force to the Rigidbody2D
        myRigidbody2D.AddForce(force);

        // Limit the speed using the maximum velocity if necessary
        if (Mathf.Abs(myRigidbody2D.velocity.x) > moveSpeed)
        {
            myRigidbody2D.velocity = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x) * moveSpeed, myRigidbody2D.velocity.y);
        }
    }
}
