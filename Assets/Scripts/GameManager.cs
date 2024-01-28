using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static Constants.GameState m_GameState = Constants.GameState.MainMenu;
    public static float m_GameTime;
    public static bool HasKey = false;
    public static bool HasTicket = false;
    public static bool HasWallet = false;
    public static bool HasPhone = false;
    public static bool HasMoney = false;
    protected override void HandleAwake()
    {
        base.HandleAwake();
        GlobalEvents.GameOverEvent += HandleGameOver;
        GlobalEvents.StateChangeEvent += HandleStartGame;
    }

    protected override void HandleDestroy()
    {
        base.HandleDestroy();
        GlobalEvents.GameOverEvent -= HandleGameOver;
        GlobalEvents.StateChangeEvent -= HandleStartGame;
    }

    private void HandleGameOver()
    {
        m_GameState = Constants.GameState.LoseGame;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void HandleStartGame()
    {
        m_GameState = Constants.GameState.InGame;
    }

    void Start()
    {
        m_GameTime = GlobalSettings.StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GameState == Constants.GameState.InGame)
        {
            m_GameTime -= Time.deltaTime;
        }
    }
}