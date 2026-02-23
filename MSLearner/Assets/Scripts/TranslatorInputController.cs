using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TranslatorInputController : MonoBehaviour
{
    public TMP_InputField mainInputField;

    public string selectedWord; // The word selected for the current game
    public string currentInput; // The player's current input

    private SceneLoader sceneLoader;
    private ASLAnimator aslAnimator;

    public GameObject restartButton;

    void Awake()
    {
        ResetInput();
        aslAnimator = GetComponent<ASLAnimator>();

    }

    public void TranslateInput()
    {
        restartButton.SetActive(false);
        currentInput = mainInputField.text;
        aslAnimator.ShowHands(currentInput.ToLower());
    }

    // Call this method to clear the current input
    public void ResetInput()
    {
        mainInputField.text = "";
        Debug.Log("Input has been reset.");
    }
}
