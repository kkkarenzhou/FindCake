using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject myPlayer; 
    public Camera mainCamera;

    public float xOffset = 2.5f;

    public void LateUpdate()
    {
        float x = myPlayer.transform.position.x + xOffset;
        float y = myPlayer.transform.position.y + xOffset;
        float z = mainCamera.transform.position.z;

        Vector3 newPosition = new Vector3(x, y, z);
        mainCamera.transform.position = newPosition; 
    }
}
