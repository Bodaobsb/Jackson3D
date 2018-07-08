using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    GameObject player;

    NavMeshAgent nav;

    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    public float visionRange;
    Animator anim;
    [SerializeField] Transform[] waypoint;
    public float dis;

	// Use this for initialization
	void Start () {
      
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

         dis = Vector3.Distance(player.transform.position, transform.position);

        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && dis < visionRange)
        {
            anim.SetBool("IsWalking", true);
           
            nav.SetDestination(player.transform.position);
        }
        else
        {
            Walk();
            //nav.enabled = false;
           
            
        }
        

	}

    void Walk()
    {
        anim.SetBool("IsWalking", true);
        int spawnPointIndex = Random.Range(0, waypoint.Length);
        nav.SetDestination(waypoint[spawnPointIndex].position);

        if (transform.position == waypoint[spawnPointIndex].position)
        {
            int spawnPointIndex2 = Random.Range(0, waypoint.Length);
            nav.SetDestination(waypoint[spawnPointIndex2].position);
        }

        


    }



}
