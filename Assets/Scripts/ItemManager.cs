using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) {
                // player.PickUpItem(this);
                Destroy(this.gameObject);
                // todo add item to inventory
                // print("Picked up item");
            }
        }
    }
}

public enum ItemType
{
    Key,
    Ticket,
    Wallet,
    Phone,
    Money,
}
