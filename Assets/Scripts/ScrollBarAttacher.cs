using UnityEngine;
using UnityEngine.UI;

public class ScrollBarAttacher : MonoBehaviour
{
    public Scrollbar scrollbarPrefab; 
    public ScrollRect targetScrollRect; 
    public float rightMargin = 10f; 

    void Start()
    {
        
        Scrollbar scrollbar = Instantiate(scrollbarPrefab, transform);

       
        targetScrollRect.verticalScrollbar = scrollbar;

        scrollbar.numberOfSteps = 0;
        scrollbar.size = 0.5f;

        
        RectTransform scrollbarRect = scrollbar.GetComponent<RectTransform>();
        scrollbarRect.anchorMin = new Vector2(1f, 0f); 
        scrollbarRect.anchorMax = new Vector2(1f, 1f); 
        scrollbarRect.anchoredPosition = new Vector2(-rightMargin, 0f); 
        scrollbarRect.sizeDelta = new Vector2(20f, 0f); 
    }
}
