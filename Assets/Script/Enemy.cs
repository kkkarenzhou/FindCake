using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player myplayer;
    public int health = 2;
    void Start(){

        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Bullet"){
            TakeDamage();
        }

        if (collision.gameObject.tag == "Player")
        {
            myplayer.TakeDamage();
        }
    }

    public void TakeDamage(){
        ColorChanger colorchanger = GetComponent<ColorChanger>();
        colorchanger.ChangeSpriteColorForDuration(Color.red,1f);

        health = health - 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
