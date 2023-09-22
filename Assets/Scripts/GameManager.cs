using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverUI;
    public SceneFader sceneFader;

    private void Awake()
    {
        // Ensure the GameManager persists across scene changes
        //DontDestroyOnLoad(this.gameObject);
    }
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
        gameOverUI.SetActive(true);

    }

    public void WinLevel()
    {
        Debug.Log("Level Won!");
        int levelToUnlock = PlayerPrefs.GetInt("levelReached");
        string currentSceneName = sceneFader.GetSceneName();
        string prefixToRemove = "Level";

        string StringTypeLevel = currentSceneName.Substring(prefixToRemove.Length);
        int IntTypeLevel = int.Parse(StringTypeLevel);

        if(PlayerPrefs.GetInt("levelReached", 1) == IntTypeLevel)
        {
            int levelReached = PlayerPrefs.GetInt("levelReached", 1);
            PlayerPrefs.SetInt("levelReached", levelReached + 1);
           
        }
       
        string nextLevel = prefixToRemove + (IntTypeLevel + 1).ToString();
        if(nextLevel != null)
        {
            sceneFader.FadeTo(nextLevel);
        }
    }
}
