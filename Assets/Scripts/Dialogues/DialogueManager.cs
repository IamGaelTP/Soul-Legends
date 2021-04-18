using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public int stopIndex;
    public float typingDelay;
    public static bool isDialogueEnd = false;

    private void Start()
    {
        index = 0;
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        isDialogueEnd = false;
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingDelay);
        }
        index++;
        isDialogueEnd = true;
    }

    private void Update()
    {
        InitDialogues();
    }

    void InitDialogues()
    {
        if (isDialogueEnd == true)
        {
            textDisplay.text = "";

            if (index <= stopIndex)
                StartCoroutine(Type());
        }
    }

    void ContinueDialogues()
    {
        stopIndex = sentences.Length;
    }

}
