using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ASLAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject a;

    [SerializeField]
    private GameObject b;

    [SerializeField]
    private GameObject c;

    [SerializeField]
    private GameObject d;

    [SerializeField]
    private GameObject e;

    [SerializeField]
    private GameObject f;

    [SerializeField]
    private GameObject g;

    [SerializeField]
    private GameObject h;

    [SerializeField]
    private GameObject i;

    [SerializeField]
    private GameObject j;

    [SerializeField]
    private GameObject k;

    [SerializeField]
    private GameObject l;

    [SerializeField]
    private GameObject m;

    [SerializeField]
    private GameObject n;

    [SerializeField]
    private GameObject o;

    [SerializeField]
    private GameObject p;

    [SerializeField]
    private GameObject q;

    [SerializeField]
    private GameObject r;

    [SerializeField]
    private GameObject s;

    [SerializeField]
    private GameObject t;

    [SerializeField]
    private GameObject u;

    [SerializeField]
    private GameObject v;

    [SerializeField]
    private GameObject w;

    [SerializeField]
    private GameObject x;

    [SerializeField]
    private GameObject y;

    [SerializeField]
    private GameObject z;

    [Header("Animation Settings")]
    public float transitionDuration = 1f; // Duration of transition between hands
    public GameObject restartButton;

    [Header("Spinning Settings")]
    public float spinSpeed = 100f; // Speed of spinning when stopped
    public bool startSpinningOnStop = true; // Optionally start spinning when stopped

    private GameObject currentHand;
    private bool isAnimating = false;
    private bool isSpinning = false;

    public Vector3 instantiatePosition = new Vector3(-0.043f, 0.216f, 0f); // Position for instantiation

    public Transform container;
    private bool isPaused = false;

    private string word;

    public void ShowHands(string chosenWord)
    {
        word = chosenWord;
        StartCoroutine(AnimateWord(word));
        //restartButton.onClick.AddListener(RestartAnimation);
    }

    private IEnumerator AnimateWord(string word)
    {
        isAnimating = true;

        foreach (char letter in word)
        {
            while (isPaused)
            {
                yield return null; // Wait for next frame
            }
            
            // Instantiate the hand prefab for the letter
            //Debug.Log(letter);
            if (currentHand != null)
            {
                Destroy(currentHand);
                //Debug.Log("Destroy");
            }

            //Debug.Log($"Processing letter: {letter}");
            GameObject handPrefab = GetHandPrefab(letter);
            //Debug.Log($"Prefab found: {handPrefab != null}");

            if (handPrefab != null)
            {
                //Debug.Log("Inst");
                currentHand = Instantiate(handPrefab, new Vector3(-1.8738f, 19f, 130f), Quaternion.Euler(90f, 0f, 0f));
                currentHand.transform.localScale *= 50f;
            }

            // Wait for the transition duration or until stopped
            float elapsed = 0f;

            while (elapsed < transitionDuration && isAnimating)
            {
                elapsed += Time.deltaTime;
                yield return null;
            }

            if (!isAnimating) break;
        }

        isAnimating = false;

        restartButton.SetActive(true);

        if (currentHand != null && startSpinningOnStop)
        {
            AddSpinComponent();
        }
    }

    private GameObject GetHandPrefab(char letter)
    {
        switch (char.ToLower(letter))
        {
            case 'a': return a;
            case 'b': return b;
            case 'c': return c;
            case 'd': return d;
            case 'e': return e;
            case 'f': return f;
            case 'g': return g;
            case 'h': return h;
            case 'i': return i;
            case 'j': return j;
            case 'k': return k;
            case 'l': return l;
            case 'm': return m;
            case 'n': return n;
            case 'o': return o;
            case 'p': return p;
            case 'q': return q;
            case 'r': return r;
            case 's': return s;
            case 't': return t;
            case 'u': return u;
            case 'v': return v;
            case 'w': return w;
            case 'x': return x;
            case 'y': return y;
            case 'z': return z;
            default: return null;
        }
    }

    public void StopAnimation()
    {
        if(!isPaused)
        {
            isPaused = !isPaused;
            if (currentHand != null)
            {
                //Debug.Log("add");
                AddSpinComponent();
            }
        }
        else{
            isPaused = !isPaused;
        }

    }

    public void RestartAnimation()
    {
        restartButton.SetActive(false);
        StartCoroutine(AnimateWord(word));
    }

    private void AddSpinComponent()
    {
        var spin = currentHand.GetComponent<SpinHand>();
        if (spin == null)
        {
            spin = currentHand.AddComponent<SpinHand>();
        }
        spin.spinSpeed = spinSpeed;
        spin.enabled = true;
    }

    public void stopAndDestroy(){
        isAnimating = false;
        if (currentHand != null)
        {
            Destroy(currentHand);
        }
    }
}



// Script to spin the hand
public class SpinHand : MonoBehaviour
{
    public float spinSpeed = 100f; // Adjustable from the main script
    public bool spin = true;

    void Update()
    {
        if (spin)
        {
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        }
    }
}