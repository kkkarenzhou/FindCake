using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePro : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxAcc = 2f;
    public float maxDec = -2f;

    private Rigidbody2D rb;
    private float moveInput;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput > 0)
        {
            rb.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            _animator.SetBool("run", true);

        }
        if (moveInput < 0)
        {
            rb.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            _animator.SetBool("run", true);

        }
        if (moveInput < 0.001f && moveInput > -0.001f)
        {
            _animator.SetBool("run", false);

        }
        run();


    }

    void run() {
        float TargetSpeed = moveInput * moveSpeed;
        float speedDif = TargetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(TargetSpeed) > 0.01f) ? maxAcc : maxDec;
        float movement = speedDif * accelRate;
        //transform.localScale = moveInput > 0.001f ? new Vector3(transform.localScale.x, transform.localScale.y, 0) : new Vector3(transform.localScale.x * -1f, transform.localScale.y, 0);
        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);

    }
}
