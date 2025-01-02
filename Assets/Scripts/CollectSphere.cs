using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectSphere : MonoBehaviour
{
    public AudioSource goldSphireFX;
    public TextMeshProUGUI goldSphireNumber;
    public TextMeshProUGUI allGoldSphireNumber;
    public int goldSphireConter = 0;

    private Animator childAnimator;
    private GameObject parentObject;
    [SerializeField]private GameManeger gameManeger;
    [SerializeField] private TextMeshProUGUI pauseGoldSphireNumber;
    [SerializeField] private TextMeshProUGUI totalGoldSphireNumber;


    void Start()
    {
        parentObject = GameObject.Find("Player");// The name of the parent object
        childAnimator = parentObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        PlayerPrefs.SetInt("totalGoldSphirAmount", 0);
        PlayerPrefs.SetInt("goldSphirAmount", 0);

        pauseGoldSphireNumber.text = PlayerPrefs.GetInt("totalGoldSphirAmount").ToString();
        totalGoldSphireNumber.text = PlayerPrefs.GetInt("totalGoldSphirAmount").ToString();


    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Gold"))
        {
            goldSphireFX.Play();
            collider.gameObject.SetActive(false);
            goldSphireConter++;
            goldSphireNumber.text = goldSphireConter.ToString();
            PlayerPrefs.SetInt("goldSphirAmount", goldSphireConter);
            PlayerPrefs.SetInt("totalGoldSphirAmount",  PlayerPrefs.GetInt("goldSphirAmount"));
            Debug.Log("Liczba gold" + PlayerPrefs.GetInt("totalGoldSphirAmount"));
            pauseGoldSphireNumber.text = PlayerPrefs.GetInt("totalGoldSphirAmount").ToString();
            totalGoldSphireNumber.text = PlayerPrefs.GetInt("totalGoldSphirAmount").ToString();
            
        }

        if (collider.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("GameSection") && !collider.CompareTag("Obstacle"))
        {
            Debug.Log("Exit is working");
            Destroy(collider.gameObject);


        }
    }

    void Die()
    {
        GetComponent<PlayerMovnent>().enabled = false;

        childAnimator.SetTrigger("Death");
        Debug.Log("This is obsticle!");
        StartCoroutine(DelayDeathAnimation(childAnimator.GetCurrentAnimatorStateInfo(0).length + 1));
        
    }

    IEnumerator DelayDeathAnimation(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        gameManeger.GameOver();
    }

}
