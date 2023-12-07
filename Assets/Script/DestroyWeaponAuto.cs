using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWeaponAuto : MonoBehaviour
{
    public float left = -20f;
    public float right = 10f;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > right || transform.position.x < left) {
            Destroy(gameObject);
        }
    }
}
