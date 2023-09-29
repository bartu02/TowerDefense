using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private void Start()
    {
        roundsText.text = PlayerStats.Rounds + "";
    }
    public void Retry()
    {
        //RestartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*private void RestartGame()
    {
        GameManager.GameIsOver = false;
        Time.timeScale = 1;
    }*/
}
