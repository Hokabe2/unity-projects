using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;

    public string[] sentences;

    [SerializeField]
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject Start_the_game;
    public GameObject Exit;


    void Start()
    {
        Exit.SetActive(false);
        continueButton.SetActive(false);
        textDisplay.text = "";
        Start_Setences();
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void Start_Setences()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            index = 0;
            textDisplay.text = "";
            continueButton.SetActive(false);
            Start_the_game.SetActive(true);
            Exit.SetActive(true);
        }
    }

}
