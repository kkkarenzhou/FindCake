using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Restart : MonoBehaviour
{
    public GameObject oldPrefab;  
    public GameObject newPrefab;
    private Button button;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }


    void OnButtonClick()
    {
        DestroyAndInstantiatePrefab(oldPrefab, newPrefab);
    }

    void DestroyAndInstantiatePrefab(GameObject objectToDestroy, GameObject prefabToInstantiate)
    {
        
        Destroy(objectToDestroy);

        GameObject newObject = Instantiate(prefabToInstantiate);
    }
}
