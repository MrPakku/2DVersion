using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueField : MonoBehaviour
{
    public Text dialogueText;
    private void Awake()
    {
        Hide();
    }

    public void show()
    {
        gameObject.SetActive(true);
        dialogueText.text = "The Enemy fainted do you\nwant to kill him?";
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
