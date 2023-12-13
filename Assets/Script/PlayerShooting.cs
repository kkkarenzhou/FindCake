using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    private AudioSource audio;
    private Rigidbody2D myRigidbody2D;

    void Start()
    {

        myRigidbody2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();



    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audio.PlayOneShot(audio.clip);
            Vector3 playerPosition = transform.position;

            float playerRotation = myRigidbody2D.transform.eulerAngles.y;
            GameObject bullet = Instantiate(bulletPrefab, playerPosition, Quaternion.Euler(0f, playerRotation, 0f));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (playerRotation == 0)
            {
                rb.velocity = new Vector2(bulletSpeed, 0f);
            }
            else
            {
                rb.velocity = new Vector2(-bulletSpeed, 0f);
            }

        }
    }
}

