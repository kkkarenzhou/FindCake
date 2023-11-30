using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control the speed of movement
    public Rigidbody2D myRigidbody2D;
    public Animator _animator;
    public float horizontalForce = 10f; // Adjust this value to control the force applied horizontally.

    private float x;
    private float y;

    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (x > 0) {
            myRigidbody2D.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            _animator.SetBool("run", true);
        
        }
        if (x < 0)
        {
            myRigidbody2D.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            _animator.SetBool("run", true);

        }
        if (x < 0.001f && x> -0.001f)
        {
            _animator.SetBool("run", false);

        }
        run();
 
        }

    private void run() {
        Vector3 movement = new Vector3(x, y, z: 0);
        myRigidbody2D.transform.position += movement * moveSpeed * Time.deltaTime;
    }
    }

