using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Player player; 
    public GameObject ballPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ballPrefab, transform.position, transform.rotation);
            player.IncrementBallCount();
        }
    }
}
