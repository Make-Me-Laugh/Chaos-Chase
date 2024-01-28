using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static GameState m_GameState = GameState.MainMenu;
    public static float m_GameTime;
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
        m_GameState = GameState.LoseGame;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void HandleStartGame()
    {
        m_GameState = GameState.InGame;
    }

    void Start()
    {
        m_GameTime = GlobalSettings.StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GameState == GameState.InGame)
        {
            m_GameTime -= Time.deltaTime;
        }
    }
}

public enum GameState
{
    MainMenu,
    InGame,
    Paused,
    WinGame,
    LoseGame,
}