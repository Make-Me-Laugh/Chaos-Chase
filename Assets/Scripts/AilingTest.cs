using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AilingTest : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
        }
    }
}
