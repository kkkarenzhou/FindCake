using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void ChangeSpriteColorForDuration(Color newColor, float duration)
    {
        // Change the sprite color
        spriteRenderer.color = newColor;
        if (HasParameter("Shooted", _animator))
          _animator.SetBool("Shooted", true);
        
        

        // Start a coroutine to revert the color after the specified duration
        StartCoroutine(RevertColorAfterDelay(duration));
    }

    private IEnumerator RevertColorAfterDelay(float delay)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(delay);

        // Revert the sprite color to its original color (you can adjust this if needed)
        spriteRenderer.color = Color.white;
        if (HasParameter("Shooted", _animator))
            _animator.SetBool("Shooted", false);
        
    }

    public static bool HasParameter(string paramName, Animator animator)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
                return true;
        }
        return false;
    }

}
