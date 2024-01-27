using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        print(hit.collider.gameObject.tag);
        if (!(hit.collider != null && hit.collider.gameObject.tag == "Player")) {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        else {
            agent.isStopped = true;
        }
        
    }
}
