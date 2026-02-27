using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputButton : MonoBehaviour
{
    public TMP_Text ShowText;

    public string selectedWord; // The word selected for the current exercise
    public string currentInput; // The users's current input

    public GameObject letterImagePrefab; // Prefab for the letter images
    public Transform container; // The container with HorizontalLayoutGroup

    [Header("Image of Signs Prefabs")]
    [SerializeField]
    private Sprite a;

    [SerializeField]
    private Sprite b;

    [SerializeField]
    private Sprite c;

    [SerializeField]
    private Sprite d;

    [SerializeField]
    private Sprite e;

    [SerializeField]
    private Sprite f;

    [SerializeField]
    private Sprite g;

    [SerializeField]
    private Sprite h;

    [SerializeField]
    private Sprite i;

    [SerializeField]
    private Sprite j;

    [SerializeField]
    private Sprite k;

    [SerializeField]
    private Sprite l;

    [SerializeField]
    private Sprite m;

    [SerializeField]
    private Sprite n;

    [SerializeField]
    private Sprite o;

    [SerializeField]
    private Sprite p;

    [SerializeField]
    private Sprite q;

    [SerializeField]
    private Sprite r;

    [SerializeField]
    private Sprite s;

    [SerializeField]
    private Sprite t;

    [SerializeField]
    private Sprite u;

    [SerializeField]
    private Sprite v;

    [SerializeField]
    private Sprite w;

    [SerializeField]
    private Sprite x;

    [SerializeField]
    private Sprite y;

    [SerializeField]
    private Sprite z;

    private SceneLoader sceneLoader;
    private ButtonAnimation buttonAnimation;
    
    void Awake()
    {
        ResetInput();

        // Select a random word from the list
        selectedWord = WordList.words[Random.Range(0, WordList.words.Count)];
        //Show the selected word on screen
        ShowText.text = selectedWord;

        sceneLoader = GetComponent<SceneLoader>();
        buttonAnimation = GetComponent<ButtonAnimation>();
    }

    // Method to add letter of pressed button to the imput
    public void AddLetter(string letter)
    {
        currentInput += letter;
        // Add image whith pressed sign to the input field on screen
        applyImage(letter);
    }

    // Method to clear the current input
    public void ResetInput()
    {
        currentInput = "";
        DeleteAllInputObjects();
    }

    // Method to check the correctness of inputted text
    public void CheckInput()
    {
        if (currentInput.ToLower() == selectedWord.ToLower())
        {
            // Play the UI slide animation
            buttonAnimation.switchButton();
            // Reload the scene
            sceneLoader.LoadEnglishToASL();
        }
        else
        {
            ResetInput();
        }
    }

    // Method to delete clear the inputfield on screen
    public void DeleteAllInputObjects()
    {
        GameObject[] inputObjects = GameObject.FindGameObjectsWithTag("Input");
        foreach (GameObject obj in inputObjects)
        {
            Destroy(obj);
        }
    }

    // Method to add the image of a sign to the inputfield
    public void applyImage(string letter){
        GameObject newLetterImage = Instantiate(letterImagePrefab, container);
        switch (letter.ToLower())
        {
            case "a":
                newLetterImage.GetComponent<Image>().sprite = a;
                break;
            case "b":
                newLetterImage.GetComponent<Image>().sprite = b;
                break;
            case "c":
                newLetterImage.GetComponent<Image>().sprite = c;
                break;
            case "d":
                newLetterImage.GetComponent<Image>().sprite = d;
                break;
            case "e":
                newLetterImage.GetComponent<Image>().sprite = e;
                break;
            case "f":
                newLetterImage.GetComponent<Image>().sprite = f;
                break;
            case "g":
                newLetterImage.GetComponent<Image>().sprite = g;
                break;
            case "h":
                newLetterImage.GetComponent<Image>().sprite = h;
                break;
            case "i":
                newLetterImage.GetComponent<Image>().sprite = i;
                break;
            case "j":
                newLetterImage.GetComponent<Image>().sprite = j;
                break;
            case "k":
                newLetterImage.GetComponent<Image>().sprite = k;
                break;
            case "l":
                newLetterImage.GetComponent<Image>().sprite = l;
                break;
            case "m":
                newLetterImage.GetComponent<Image>().sprite = m;
                break;
            case "n":
                newLetterImage.GetComponent<Image>().sprite = n;
                break;
            case "o":
                newLetterImage.GetComponent<Image>().sprite = o;
                break;
            case "p":
                newLetterImage.GetComponent<Image>().sprite = p;
                break;
            case "q":
                newLetterImage.GetComponent<Image>().sprite = q;
                break;
            case "r":
                newLetterImage.GetComponent<Image>().sprite = r;
                break;
            case "s":
                newLetterImage.GetComponent<Image>().sprite = s;
                break;
            case "t":
                newLetterImage.GetComponent<Image>().sprite = t;
                break;
            case "u":
                newLetterImage.GetComponent<Image>().sprite = u;
                break;
            case "v":
                newLetterImage.GetComponent<Image>().sprite = v;
                break;
            case "w":
                newLetterImage.GetComponent<Image>().sprite = w;
                break;
            case "x":
                newLetterImage.GetComponent<Image>().sprite = x;
                break;
            case "y":
                newLetterImage.GetComponent<Image>().sprite = y;
                break;
            case "z":
                newLetterImage.GetComponent<Image>().sprite = z;
                break;
            default:
                Debug.LogWarning("Letter not recognized: " + letter);
                break;
        }
    }
}
