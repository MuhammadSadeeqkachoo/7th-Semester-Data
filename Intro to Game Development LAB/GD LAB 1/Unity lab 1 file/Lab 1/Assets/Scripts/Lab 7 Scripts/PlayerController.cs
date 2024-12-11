using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveX, moveZ;
    public float speed = 10;
    float centerToEdge = 48f;
    [SerializeField]
    private GameObject enemyCube;
    [SerializeField]
    private GameObject GameOverPanel;
    RaycastHit hit;
    int scoreNumb = 0;
    public Text scoreText;
    public Text Highscore;


    // Start is called before the first frame update
    private void Start()
    {
        if(Time.timeScale == 0) { Time.timeScale = 1; }
        SetColor(gameObject, Color.blue);
        InvokeRepeating("EnemySpawn", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        // Get axis inputs
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrow keys

        // Calculate movement vector
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // Move the player
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        scoreText.text = $"Score : {scoreNumb}";

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    scoreNumb++;
                    Destroy(hit.collider.gameObject,1f);
                    hit.collider.gameObject.GetComponent<EnemyController>().isstopped = true;
                }
            }
        }

        if (Time.timeScale == 0)
        {
            ScoreManager.GameOver(scoreNumb);
            Highscore.text = ScoreManager.highscore.ToString();
            GameOverPanel.SetActive(true);
        }

    }

    void EnemySpawn()
    {
        Vector3 randomLocationOnPlane = new Vector3(Random.Range(-centerToEdge, centerToEdge), 1.5f, Random.Range(-centerToEdge, centerToEdge));
        Instantiate(enemyCube, randomLocationOnPlane, Quaternion.identity);
    }

    private void SetColor(GameObject obj, Color color)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

}
