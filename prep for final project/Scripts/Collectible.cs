using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Player myPlayer = collider.gameObject.GetComponent<Player>();

        if (myPlayer != null)
        {
            myPlayer.IncrementScore();
            Destroy(gameObject);
        }
    }
}
