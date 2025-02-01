using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController11 : MonoBehaviour
{

    public NavMeshAgent Agent;
    public GameObject Player;
    Animator animator;
    private int walkHash, punchHash,defeatHash;
    
    public float enemyHealth = 100;
    public AudioSource punchSound;
    public GameObject victoryPanel;
    public Image Healthbar;


    // Start is called before the first frame update
    void Start()
    {
        punchSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        walkHash = Animator.StringToHash("isWalking");
        punchHash = Animator.StringToHash("Punch");
        defeatHash = Animator.StringToHash("EnemyHealth");



        Agent = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Agent.updateRotation = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, Player.transform.position) < 5f)
        {
            Agent.SetDestination(Player.transform.position);
            animator.SetBool(walkHash, true);
            if(Vector3.Distance(transform.position, Player.transform.position) < 1.5f)
            {
                animator.SetTrigger(punchHash);
            }
        }

        else
        {
            Agent.ResetPath();
            animator.SetBool(walkHash, false);
        }

    }

    public void PunchSound()
    {
        punchSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            TakeDamage(20);
            animator.SetFloat(defeatHash, enemyHealth);


        }
    }



    void TakeDamage(float Damage)
    {
        enemyHealth -= Damage;
        Healthbar.fillAmount -= Damage / 100;
    }

    public void EnemyDied()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }



}