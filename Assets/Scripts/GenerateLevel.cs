using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sections;
    
    public int pozytionZ = 38;
    public bool addSection = false;
    public int sectionNumber;
    //public GameObject nextSpawnPoint;
    Vector3 nextSpawnPointV;
    private GenerateSet generateSet;

    void Start()
    {
        //nextSpawnPointV = nextSpawnPoint.transform.position;
        
    }

    void Update()
    {
        if(addSection == false)
        {
            
            addSection = true;
            StartCoroutine(GenerateSection());
        }

        IEnumerator GenerateSection()
        {
            sectionNumber = Random.Range(0,sections.Length - 1);
            //GameObject temp =  Instantiate(sections[sectionNumber], new Vector3(0, 0, pozytionZ), Quaternion.identity);
            GameObject temp = Instantiate(sections[sectionNumber], nextSpawnPointV, Quaternion.identity);
            nextSpawnPointV = temp.transform.GetChild(1).transform.position;
            //generateSet.GenerateSetOfObjects();
             yield return new WaitForSeconds(2);
            addSection = false;
        }
    }
}
