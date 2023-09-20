using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour
{
    public GameObject buttonPrefab;

    private const int levelCount = 300;

    public LevelSelector levelSelector;
    private void Start()
    {
        for (int i = 0; i < levelCount; i++)
        {
           
            int levelIndex = i+1; 

            GameObject button = Instantiate(buttonPrefab, transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = levelIndex.ToString();

            Button buttonComponent = button.GetComponent<Button>();

            buttonComponent.onClick.AddListener(() => levelSelector.Select("Level" + levelIndex.ToString()));
        }

    }
}
