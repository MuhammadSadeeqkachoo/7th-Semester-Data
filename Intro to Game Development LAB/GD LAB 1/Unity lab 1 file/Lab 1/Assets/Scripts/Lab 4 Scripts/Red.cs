using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    bool increase = true;

    // Update is called once per frame
    void Update()
    {

        if (increase)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
            if (transform.localScale.y >= 5) { increase = false; }
        }
        else if (!increase)
        {
            transform.localScale -= Vector3.one * Time.deltaTime;
            if (transform.localScale.y <= 1) { increase = true; }

        }
    }
}
