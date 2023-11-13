using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public TextMeshProUGUI [] roundsText;
    private void Start()
    {
        GameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        StartCoroutine(AnimateText());
        gameOverUI.SetActive(true);
        //Time.timeScale = 0;     When pressing retry button after losing the level, it doesn't load the level: gives dark screen.

    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
        
    }
    IEnumerator AnimateText()
    {
        for(int i=0;i<roundsText.Length;i++)
        {
            roundsText[i].text = "0";
        }
        int round = 0;

        yield return new WaitForSeconds(0.7f);

        while (round < PlayerStats.Rounds - 1)
        {
            round++;
            for(int i=0;i<roundsText.Length;i++)
            {
                roundsText[i].text = round.ToString();
            }
            

            yield return new WaitForSeconds(0.05f);
        }

    }
}
