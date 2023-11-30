using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Player myPlayer = collision.gameObject.GetComponent<Player>();

        if (myPlayer != null)
        {
            myPlayer.TakeDamage();
        }
    }
}
