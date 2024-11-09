using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCube;

    float centerToEdge = 24f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
        Vector3 randomLocationOnPlane = new Vector3(Random.Range(-centerToEdge, centerToEdge), 1, Random.Range(-centerToEdge, centerToEdge));
        Instantiate(enemyCube, randomLocationOnPlane,Quaternion.identity);
        }
    }
}
