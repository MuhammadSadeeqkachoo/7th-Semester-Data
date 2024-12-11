using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float enemySpeed = 5f;
    [SerializeField] GameObject Player;
    public bool isstopped = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        SetColor(gameObject, Color.red);

    }

    private void Update()
    {
        if (!isstopped)
        {
            MoveEnemyTowardsPlayer(gameObject);
        }
    }

    private void MoveEnemyTowardsPlayer(GameObject enemy)
    {
        Vector3 direction = (Player.transform.position - enemy.transform.position).normalized;
        enemy.transform.position += direction * enemySpeed * Time.deltaTime;
    }

    private void SetColor(GameObject obj, Color color)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
        }
    }
}
