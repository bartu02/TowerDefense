using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string leveltoLoad = "MainLevel";

    public SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo(leveltoLoad);
    }

    public void Quit()
    {
        Debug.Log("Bye!");
        Application.Quit();
    }
}
