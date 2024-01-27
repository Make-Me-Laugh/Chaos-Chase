using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private bool hasLineOfSight = false;

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
        if (hasLineOfSight) {
            agent.isStopped = true;
        }
        else {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
    }

    private void FixedUpdate() {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null) {
            hasLineOfSight = ray.collider.gameObject.CompareTag("Player");
        }
    }
}
