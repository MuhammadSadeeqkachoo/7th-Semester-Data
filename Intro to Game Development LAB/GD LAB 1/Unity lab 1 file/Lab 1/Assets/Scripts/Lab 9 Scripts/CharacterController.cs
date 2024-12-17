using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Animator animator;
    public float speed = 1.0f;
    private Quaternion targetRotation;
    public float rotationSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            animator.SetBool("isWalking", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            targetRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.S)) 
        {
            animator.SetBool("isWalking", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            targetRotation = Quaternion.Euler(0, 180, 0);


        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.A)) 
        { 
            animator.SetBool("isWalking",true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            targetRotation = Quaternion.Euler(0, -90, 0);

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.D)) 
        {
            animator.SetBool("isWalking", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            targetRotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
