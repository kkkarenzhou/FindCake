using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 30f; // Degrees per second

    public void Update()
    {
        // Rotate the GameObject every frame
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
