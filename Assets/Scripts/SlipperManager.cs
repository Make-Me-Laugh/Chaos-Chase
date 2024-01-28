using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlipperManager : MonoBehaviour
{
    [SerializeField] float torque = 20f;
    private Rigidbody2D rb;
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

    private void OnCollisionEnter2D(Collision2D other) {
        // print("1111");
        if (other.gameObject.CompareTag("Player")) {
            // print("hihih");
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) {
                // player.PickUpItem(this);
                if (player.health > 0) {
                    player.health -= 1;
                }
                else if (player.health == 0) {
                    SceneManager.LoadScene("Lose");
                }
            }
        }
    }

    private IEnumerator Disappear() {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
