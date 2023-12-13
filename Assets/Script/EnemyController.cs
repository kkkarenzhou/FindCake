using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fireRate = 2f;
    public float bulletSpeed = 10f;
    public int health = 3;
    public Player myplayer;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float timeToFire = 0f;
    private Rigidbody2D myRigidbody2D;
    private Animator _animator;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        bool shooted = _animator.GetBool("Shooted");
        if (!shooted)
        { Move();
        }

       
        
        if (Time.time >= timeToFire)
        {
            if (!shooted)
            {
                Shoot();
            }
            
            timeToFire = Time.time + 1f / fireRate;
        }
    }

    void Move()
    {
        
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (transform.position.x >= 15f)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, 0);
            moveSpeed *= -1f;
        }
        if (transform.position.x <= 2.5f)
            {
            
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, 0);
            moveSpeed *= -1f;
            }
    }

    void Shoot()
    {

        float playerRotation = transform.localScale.x;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (playerRotation > 0) { 
            rb.velocity = new Vector2(bulletSpeed, 0f);
    }
            else {
                rb.velocity = new Vector2(-bulletSpeed, 0f);
}

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }

        if (collision.gameObject.tag == "Player")
        {
            myplayer.TakeDamage();
        }
    }

    public void TakeDamage()
    {
        ColorChanger colorchanger = GetComponent<ColorChanger>();
        colorchanger.ChangeSpriteColorForDuration(Color.red, 2f);

        health = health - 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}