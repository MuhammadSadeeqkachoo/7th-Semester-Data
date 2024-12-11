using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab7Enemy : MonoBehaviour
{   
    // Update is called once per frame
    [SerializeField]
    private GameObject enemyCube;

    float centerToEdge = 48f;

    private void Start()
    {
        InvokeRepeating("EnemySpawn", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

            
    }

    void EnemySpawn()
    {
        Vector3 randomLocationOnPlane = new Vector3(Random.Range(-centerToEdge, centerToEdge), 1.5f, Random.Range(-centerToEdge, centerToEdge));
        Instantiate(enemyCube, randomLocationOnPlane, Quaternion.identity);
    }
}
