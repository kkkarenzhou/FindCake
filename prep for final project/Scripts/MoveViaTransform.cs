using UnityEngine;

public class MoveViaTransform : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control the speed of movement

    public SpriteRenderer mySpriteRenderer;

    private void Update()
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

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // Apply the movement to the transform's position
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
