using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSet : MonoBehaviour
{
    public GameObject[] setsOfObjects;
    public int setNumber;

    void Start()
    {
        GenerateSetOfObjects();
    }


    public void GenerateSetOfObjects()
    {
        setNumber = Random.Range(0, setsOfObjects.Length - 1);
        setsOfObjects[setNumber].SetActive(true);
    }
}
