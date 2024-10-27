using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Green : MonoBehaviour
{
    private bool up = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("World");
    }

    void Update()
    {
        if (up)
        {
            transform.position += Vector3.up * Time.deltaTime;
            if (transform.position.y >= 10) { up = false; }
        }
        else if (!up)
        {
            transform.position += Vector3.down * Time.deltaTime;
            if (transform.position.y <= 0) { up = true; }
        }
    }
}
