using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    // Inputfield text
    public TMP_InputField mainInputField;

    public string selectedWord; // The word selected for the current exercise
    public string currentInput; // The users's current input

    private SceneLoader sceneLoader;
    private ASLAnimator aslAnimator;
    private ButtonAnimation buttonAnimation;

    public GameObject startButton; // Button that acivates the hand animation and needs to be hidden after it



    void Awake()
    {
        ResetInput();

        // Select a random word from the list
        selectedWord = WordList.words[Random.Range(0, WordList.words.Count)];
        sceneLoader = GetComponent<SceneLoader>();

        Debug.Log("The word is: " + selectedWord);

        aslAnimator = GetComponent<ASLAnimator>();
        buttonAnimation = GetComponent<ButtonAnimation>();
    }

    // Play the 3d hand "aniamtion"
    public void StartExercise(){
        aslAnimator.ShowHands(selectedWord);
        // turn of button that starts this process
        startButton.SetActive(false);
    }

    // Method to check the correctness of inputted text
    public void CheckInput()
    {
        // Get the text from the inputfield
        currentInput = mainInputField.text;
        
        if (currentInput.ToLower() == selectedWord.ToLower())
        {
            // Stop hand animation and remove gand from screen
            aslAnimator.stopAndDestroy();
            // Play UI slide aniamtion
            buttonAnimation.switchButton();
            // Reload the scene
            sceneLoader.LoadASLToEnglish();
        }
        else
        {
            // Clear the input
            ResetInput();
        }
    }

    // Method to clear the current input
    public void ResetInput()
    {
        mainInputField.text = "";
    }
}
