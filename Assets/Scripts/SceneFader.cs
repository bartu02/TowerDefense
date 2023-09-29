using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    
    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime * 0.7f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.7f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }

    public static string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static int LevelToInt()
    {
        string currentSceneName = GetSceneName();
        string prefixToRemove = "Level";

        string StringTypeLevel = currentSceneName.Substring(prefixToRemove.Length);

        return int.Parse(StringTypeLevel);

    }
    public string NextLevelToString(int IntTypeLevel)
    {
        string prefixToRemove = "Level";
        string nextLevel = prefixToRemove + (IntTypeLevel + 1).ToString();

        return nextLevel;

    }
}
