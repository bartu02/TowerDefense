using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    List<GameObject> levelButtons = new List<GameObject>();

    public static readonly int levelCount = 10;

    

    private void Start()
    {
        for(int i = 0;i<levelButtons.Count;i++)
        {
            int levelReached = PlayerPrefs.GetInt("levelReached", 1);
            if(levelReached < i + 1)
            {
                Image buttonImage = levelButtons[i].GetComponent<Button>().image;
                Color buttonColor = buttonImage.color;
                buttonColor.a = 0.45f;
                buttonImage.color = buttonColor;
                levelButtons[i].GetComponent<Button>().interactable = false;
            }
        }
    }
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

    public void SetButtons(GameObject btn)
    {
        levelButtons.Add(btn);
    }
}

