using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonAnims : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    private TextMeshProUGUI buttonText;
    private Vector3 originalTextScale;
    private void Start()
    {
        animator = GetComponent<Animator>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        animator.enabled = false; // Initially, disable the animator
        originalTextScale = buttonText.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.enabled = true; // Enable the animator when hovered over
        //animator.SetTrigger("HoverTrigger");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //animator.ResetTrigger("HoverTrigger");
        animator.enabled = false; // Disable the animator when the pointer exits
        buttonText.transform.localScale = originalTextScale;
    }
}


