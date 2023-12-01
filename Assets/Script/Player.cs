using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public TextMeshProUGUI healthNow;
    public TextMeshProUGUI gameOverText;
    public GameObject restart;
    [HideInInspector]
    public int score = 0;
  
    private Rigidbody2D myRigidbody; 
    private Animator myAnimator;
    private bool getCake = false;
    private int totalscore = 20;
    
    public void Start()
    {
        //Debug.Log(healthNow.text);
        healthNow.text = health.ToString();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    public void Update()
    {
        GameOver();
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Goal goal = collision.gameObject.GetComponent<Goal>();

        if (goal != null)
        {
            score = score + goal.points;

        }
        if(collision.gameObject.tag == "Cake"){
            getCake = true;
            //Destroy(collision.gameObject);

        }
    
    }


    public void TakeDamage()
    {
        ColorChanger colorchanger = GetComponent<ColorChanger>();
        colorchanger.ChangeSpriteColorForDuration(Color.red,1f);
        health = health - 1;
        healthNow.text = health.ToString();
    }

    public void GameOver()
    {
        
        if (health <= 0)
        {
            Destroy(healthNow);
            restart.SetActive(true);
            gameOverText.enabled = true;
            gameOverText.text = "You died";
        }
        else {
            if(score == totalscore && getCake)
            {
                Destroy(healthNow);
                restart.SetActive(true);
                gameOverText.enabled = true;
                gameOverText.text = "You got the cake with price " + score;
            }
            else if(!(score == totalscore) && getCake){
                gameOverText.enabled = true;
                gameOverText.text = "You don't have enough money for the cake";
                Invoke("DisableText", 2f);

            }





        }

    }

    void DisableText()
    {
        // Disable the Text component
        gameOverText.enabled = false;
        getCake = false;
    }
}
