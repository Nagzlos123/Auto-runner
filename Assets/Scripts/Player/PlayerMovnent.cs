using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovnent : MonoBehaviour
{
    [SerializeField] private float speedMove = 3;
    [SerializeField] private float speedLeftRight = 4;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float checkDistans;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    private GameObject parentObject;
  

    Vector3 velocity;
    private Animator childAnimator;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        parentObject = GameObject.Find("Player");// The name of the parent object
        childAnimator = parentObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.GetChild(0).position, checkDistans, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

         if(isGrounded)
        {
            Debug.Log("Player is on the ground");
            childAnimator.SetBool("Jump", false);
        }
         else
        {
            Debug.Log("Player ism't on the ground");
        }
       
            transform.Translate(Vector3.forward * Time.deltaTime * speedMove, Space.World);

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * speedLeftRight);
                }

            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * speedLeftRight);
                }

            }
        



        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        childAnimator.SetBool("Jump", true);

    }
}

