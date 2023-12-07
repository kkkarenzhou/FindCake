using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public GameObject DiePage;
    public GameObject WinPage;
    public GameObject Warning;
    public TextMeshProUGUI healthNow;
    public TextMeshProUGUI totalscore_t;
    public TextMeshProUGUI scoreNow;
    public int totalscore = 20;
    public LevelControl levelcontrol;
    [HideInInspector]
    public int score = 0;
  
    private Rigidbody2D myRigidbody; 
    //private Animator myAnimator;
    private bool getCake = false;
    private ColorChanger colorchanger;


    public void Start()
    {
        //Debug.Log(healthNow.text);
        colorchanger = GetComponent<ColorChanger>();
        healthNow.text = health.ToString();
        myRigidbody = GetComponent<Rigidbody2D>();
        totalscore_t.text = totalscore.ToString();
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
            scoreNow.text = score.ToString();

        }
        if(collision.gameObject.tag == "Cake"){
            getCake = true;
            //Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "Attack") {
            TakeDamage();
        }
        if (collision.gameObject.tag == "Trap")
        {
            TakeDamage();
        }

    }


    public void TakeDamage()
    {
        
        colorchanger.ChangeSpriteColorForDuration(Color.red,1f);
        health = health - 1;
        healthNow.text = health.ToString();
    }

    public void GameOver()
    {

        if (health <= 0)
        {
            Destroy(healthNow);
            DiePage.SetActive(true);
        }
        else
        {
            if (score == totalscore && getCake)
            {
                Destroy(healthNow);
                WinPage.SetActive(true);
                //FinishLevel();
            }
            else if (!(score == totalscore) && getCake)
            {
                Warning.SetActive(true);
                Invoke("DisableText", 2f);

            }





        }

    }

    void DisableText()
    {
            // Disable the Text component
            Warning.SetActive(false);
        getCake = false;
    }

    /*void FinishLevel() {
        foreach (PlayerButtonPair pair in levelcontrol.playerButtonPairs)
        {
            if (pair.player == gameObject)
            {
                pair.button.interactable = true;
            }
        }

    }*/

}
