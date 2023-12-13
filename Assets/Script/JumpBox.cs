using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    public float jumpVelocity = 9f;
    public LayerMask mask;
    public float boxHeight;

    private Vector2 PlayerSize;
    private Vector2 boxSize;

    private bool jumpRequest = false;
    private bool grounded = false;

    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        PlayerSize = GetComponent<SpriteRenderer>().bounds.size;
        boxSize = new Vector2(PlayerSize.x*0.8f, boxHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumpRequest = true;
        }
    }
    void FixedUpdate() {

        if (jumpRequest)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
            grounded = false;
        }
        else
        {
            Vector2 boxCenter = (Vector2)transform.position + (Vector2.down * PlayerSize.y * 0.5f);
            if (Physics2D.OverlapBox(boxCenter, boxSize, 0, mask) != null)
            {
                grounded = true;
            }
            else {
                grounded = false;
            }
        
        }
    }
}
