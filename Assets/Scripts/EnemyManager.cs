using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private bool hasLineOfSight = false;
    float radius = 0.5f;
    float shootradius = 4f;
    private bool isShooting = false;

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
        
        if (!isShooting) {
            if (hasLineOfSight) {
                    isShooting = true;
                    agent.isStopped = true;
                    StartCoroutine(Shoot());
            }
            else {
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);
            }
        }
    }

    private void FixedUpdate() {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null) {
            hasLineOfSight = ray.collider.gameObject.CompareTag("Player") && ray.distance < shootradius;
        }
    }

    private IEnumerator Shoot() {
        print("hit");
        GameObject slipper = (GameObject)Instantiate(Resources.Load("Slipper"));
        Vector3 direction = player.transform.position - transform.position;
        slipper.transform.position = transform.position + direction.normalized * radius;
        yield return new WaitForSeconds(GlobalSettings.EnemyReloadTime);
        agent.isStopped = true;
        isShooting = false;
    }
}
