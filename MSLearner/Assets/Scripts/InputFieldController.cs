using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    public TMP_InputField mainInputField;

    public string selectedWord; // The word selected for the current game
    public string currentInput; // The player's current input

    private SceneLoader sceneLoader;
    private ASLAnimator aslAnimator;

    public GameObject startButton;



    void Awake()
    {
        ResetInput();

        // Select a random word from the list
        selectedWord = WordList.words[Random.Range(0, WordList.words.Count)];
        sceneLoader = GetComponent<SceneLoader>();

        Debug.Log("The word is: " + selectedWord);

        aslAnimator = GetComponent<ASLAnimator>();
    }

    public void StartExercise(){
        aslAnimator.ShowHands(selectedWord);
        startButton.SetActive(false);
    }

    public void CheckInput()
    {
        currentInput = mainInputField.text;
        
        if (currentInput.ToLower() == selectedWord.ToLower())
        {
            Debug.Log("Correct! The word is: " + selectedWord);
            sceneLoader.LoadASLToEnglish();
        }
        else
        {
            Debug.Log("Incorrect. Correct word: " + selectedWord + "; You inputed: " + currentInput);
            ResetInput();
        }
    }

    // Call this method to clear the current input
    public void ResetInput()
    {
        mainInputField.text = "";
        Debug.Log("Input has been reset.");
    }
}
