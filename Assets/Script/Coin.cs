using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider2D = GetComponent<CircleCollider2D>();

    }

    private void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.tag=="Player") {
            Destroy(gameObject);
        }
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
