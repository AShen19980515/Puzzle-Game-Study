using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public GameObject panel;
    public Text dialogueText;

    private void OnEnable() {
        EventHandler.ShowDialogEvent += OnShowDialogEvent;
    }

    private void OnDisable() {
        EventHandler.ShowDialogEvent -= OnShowDialogEvent;
    }

    private void OnShowDialogEvent(string text)
    {
        if(text != string.Empty)
          panel.SetActive(true);
        else
          panel.SetActive(false);
        dialogueText.text=text;
    }
}
