using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCarpet : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                if (GameManager.m_GameState == Constants.GameState.LoseGame)
                {
                    player.Say("R I P");
                }
                else if (!GameManager.HasKey)
                {
                    player.Say("I need a key");
                }
                else if (!GameManager.HasTicket)
                {
                    player.Say("I need a Taylor Swift ticket");
                }
                else if (!GameManager.HasWallet)
                {
                    player.Say("I need a wallet");
                }
                else if (!GameManager.HasPhone)
                {
                    player.Say("I need a phone");
                }
                else if (!GameManager.HasMoney)
                {
                    player.Say("I need some cash");
                }
                else
                {
                    SceneManager.LoadScene("Win");
                }
            }
        }
    }
}
