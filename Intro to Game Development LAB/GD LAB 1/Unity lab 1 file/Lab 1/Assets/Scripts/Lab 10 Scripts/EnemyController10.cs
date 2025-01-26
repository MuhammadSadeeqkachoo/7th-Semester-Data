using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController10 : MonoBehaviour
{

    public NavMeshAgent Agent;
    public GameObject Player;
    Animator animator;
    private int walkHash;
    private int punchHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        walkHash = Animator.StringToHash("isWalking");
        punchHash = Animator.StringToHash("Punch");


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

    
}