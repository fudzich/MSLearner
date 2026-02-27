using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TranslatorInputController : MonoBehaviour
{
    // Inputfield text
    public TMP_InputField mainInputField;

    public string currentInput; // The player's current input

    private SceneLoader sceneLoader;
    private ASLAnimator aslAnimator;

    public GameObject restartButton;

    void Awake()
    {
        ResetInput();
        aslAnimator = GetComponent<ASLAnimator>();

    }

    // Method to transalte user's input
    public void TranslateInput()
    {
        restartButton.SetActive(false);
        // Get text from inputfield
        currentInput = mainInputField.text;
        // Tranalate current input
        aslAnimator.ShowHands(currentInput.ToLower());
    }

    // Method to clear the current input
    public void ResetInput()
    {
        mainInputField.text = "";
    }
}
