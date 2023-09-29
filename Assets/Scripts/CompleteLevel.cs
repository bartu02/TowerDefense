using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    public void Continue()
    {

        int IntTypeLevel = SceneFader.LevelToInt();

        if (PlayerPrefs.GetInt("levelReached", 1) == IntTypeLevel)
        {
            int levelReached = PlayerPrefs.GetInt("levelReached", 1);
            PlayerPrefs.SetInt("levelReached", levelReached + 1);

        }
        if (LevelSelector.levelCount == IntTypeLevel)
        {
            Debug.Log("This was the last scene.");
            return;
        }
        string nextLevel = sceneFader.NextLevelToString(IntTypeLevel);

        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
