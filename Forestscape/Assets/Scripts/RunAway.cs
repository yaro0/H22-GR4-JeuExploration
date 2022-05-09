using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAway : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    private Animator animator;

    public float playerDistanceRun = 50.0f;
    public float playerDistanceRun2 = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.speed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if((distance < playerDistanceRun && UnityEngine.Input.GetKeyDown(KeyCode.LeftControl) == false) || 
        (distance < playerDistanceRun2 && UnityEngine.Input.GetKeyDown(KeyCode.LeftControl) == true)){

            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer*4;
        
            agent.SetDestination(newPos);
            //StartCoroutine(Run());
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", true);
            
        }
    
            float distanceRemain  = agent.remainingDistance;

            if(distanceRemain <= 0){
                agent.ResetPath();
                //Debug.Log("reset path");
                animator.SetBool("IsRunning", false);
            }

    }

    private IEnumerator Run(){
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsRunning", true);
        yield return new WaitForSeconds(5);
       animator.SetBool("IsRunning", false);

    }
}
