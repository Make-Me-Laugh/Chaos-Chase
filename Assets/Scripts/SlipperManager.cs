using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperManager : MonoBehaviour
{
    [SerializeField] float torque = 20f;
    private Rigidbody2D rb;
    private bool isDisappear = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(torque);
        rb.AddForce(direction.normalized * distance * 0.1f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
