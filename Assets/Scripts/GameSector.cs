using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSector : MonoBehaviour
{
    GenerateLevel generateLevel;
    // Start is called before the first frame update
    void Start()
    {
        generateLevel = FindObjectOfType<GenerateLevel>();
    }

    void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Obstacle"))
        {
            Debug.Log("Exit is working");
            Destroy(gameObject);


        }
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
