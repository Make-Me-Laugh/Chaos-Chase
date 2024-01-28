using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void ReturnToStartMenu()
    {
        GameManager.HasKey = false;
        GameManager.HasTicket = false;
        GameManager.HasWallet = false;
        GameManager.HasPhone = false;
        GameManager.HasMoney = false;
        GameManager.m_GameState = Constants.GameState.MainMenu;
        SceneManager.LoadSceneAsync(0);
    }
}
