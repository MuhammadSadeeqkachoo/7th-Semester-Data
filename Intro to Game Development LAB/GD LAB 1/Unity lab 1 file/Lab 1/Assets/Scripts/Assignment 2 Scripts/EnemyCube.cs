using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : MonoBehaviour
{

    private void OnEnable()
    {
        Destroy(gameObject,2);
    }
}
