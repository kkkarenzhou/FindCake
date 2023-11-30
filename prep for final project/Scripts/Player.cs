using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public int score; 
    public Rigidbody2D myRigidbody; 
    public Animator myAnimator;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    public void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void Update()
    {
        float xVelocity = Mathf.Abs(myRigidbody.velocity.x);
        myAnimator.SetFloat("xVelocity", xVelocity);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Goal goal = collision.gameObject.GetComponent<Goal>();

        if (goal != null)
        {
            score = score + goal.points;
            GameOver();
        }
    }

    public void IncrementScore()
    {
        score = score + 1;
    }

    public void TakeDamage()
    {
        // Step 1 - decrease health by 1
        health = health - 1;
        
        // Step 2 - if health is zero, call GameOver()
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        if (health <= 0)
        {
            gameOverText.text = "You died";
        }
        else
        {
            gameOverText.text = "You win! Score: " + score;
        }

        gameOverPanel.SetActive(true);
    }
}
