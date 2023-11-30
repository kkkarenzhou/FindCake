using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float minimumX;
    public float maximumX;
    public float speed = 5.0f;
    public SpriteRenderer mySpriteRenderer; 

    private float direction = 1;

    public void Update()
    {
        // Move the object back and forth in the x direction using speed
        // and direction.
        if (transform.position.x > maximumX)
        {
            direction = -1;
            mySpriteRenderer.flipX = true;
        }
        else if (transform.position.x < minimumX)
        {
            direction = 1;
            mySpriteRenderer.flipX = false;
        }

        float newX = direction * speed * Time.deltaTime;

        transform.position += new Vector3(newX, 0, 0);
    }
}
