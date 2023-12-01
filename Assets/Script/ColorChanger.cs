using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSpriteColorForDuration(Color newColor, float duration)
    {
        // Change the sprite color
        spriteRenderer.color = newColor;

        // Start a coroutine to revert the color after the specified duration
        StartCoroutine(RevertColorAfterDelay(duration));
    }

    private IEnumerator RevertColorAfterDelay(float delay)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(delay);

        // Revert the sprite color to its original color (you can adjust this if needed)
        spriteRenderer.color = Color.white;
    }
}
