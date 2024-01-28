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
        rb.AddForce(direction.normalized * Mathf.Max(distance, 5f), ForceMode2D.Impulse);
        StartCoroutine(Disappear());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Disappear() {
        isDisappear = true;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
