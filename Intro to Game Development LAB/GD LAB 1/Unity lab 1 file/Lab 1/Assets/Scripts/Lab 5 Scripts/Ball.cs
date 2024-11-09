using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Material Green;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Green.color;
        }
    } 
}
