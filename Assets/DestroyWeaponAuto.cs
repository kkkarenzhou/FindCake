using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWeaponAuto : MonoBehaviour
{
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 10f || transform.position.x < -20f) {
            Destroy(gameObject);
        }
    }
}
