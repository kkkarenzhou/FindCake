using UnityEngine;

public class DoubleHitPeg : MonoBehaviour
{
    public int hitCount;
    public Color spriteColor = Color.grey;
    public SpriteRenderer mySpriteRenderer;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        hitCount = hitCount + 1;

            if ( hitCount == 1 )
            {
                mySpriteRenderer.color = spriteColor;
            }

            if (hitCount == 2)
            {
                Destroy(gameObject);
            }

    }
}