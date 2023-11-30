using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Rigidbody2D myRigidbody2D;
    public float bulletSpeed = 10f;

    void Start() {

        myRigidbody2D = GetComponent<Rigidbody2D>();



    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Vector3 playerPosition = transform.position;

            float playerRotation = myRigidbody2D.transform.eulerAngles.y;
            GameObject bullet = Instantiate(bulletPrefab, playerPosition, Quaternion.Euler(0f, playerRotation, 0f));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (playerRotation == 0) 
            {   Debug.Log(playerRotation); 
                rb.velocity = new Vector2(bulletSpeed,0f);
                Debug.Log(rb.velocity);
            }
            else {
                Debug.Log(playerRotation);
                rb.velocity = new Vector2(-bulletSpeed, 0f);
                Debug.Log(rb.velocity);
            }
           
        }
    }

}