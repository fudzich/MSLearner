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
    public Button stopButton;

    [Header("Spinning Settings")]
    public float spinSpeed = 100f; // Speed of spinning when stopped
    public bool startSpinningOnStop = true; // Optionally start spinning when stopped

    private GameObject currentHand;
    private bool isAnimating = false;
    private bool isSpinning = false;

    public Vector3 instantiatePosition = new Vector3(-0.043f, 0.216f, 0f); // Position for instantiation

    public Transform container;

    public void ShowHands(string word)
    {
        StartCoroutine(AnimateWord(word));
        stopButton.onClick.AddListener(StopAnimation);
    }

    private IEnumerator AnimateWord(string word)
    {
        isAnimating = true;

        foreach (char letter in word)
        {
            
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
                currentHand = Instantiate(handPrefab, new Vector3(-1.8738f, 26.137f, 156.1f), Quaternion.Euler(90f, 0f, 0f));
                currentHand.transform.localScale *= 50f;
                //SpawnHand(handPrefab);
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

        if (currentHand != null && startSpinningOnStop)
        {
            AddSpinComponent();
        }
    }

    private void SpawnHand(GameObject handPrefab)
    {
        // Get the container's renderer to access bounds
        Renderer containerRenderer = container.GetComponent<Renderer>();
        if (containerRenderer == null)
        {
            Debug.LogError("Container does not have a Renderer component.");
            return;
        }

        Vector3 containerSize = containerRenderer.bounds.size;

        // Determine scale for the hand (e.g., half the container size)
        Vector3 handScale = containerSize * 0.5f;

        // Instantiate the hand as a child of the container
        GameObject handInstance = Instantiate(handPrefab, container.transform);
        handInstance.transform.localScale = handScale;

        // Set a fixed local position inside the container
        // For example, at the center or a specific point
        Vector3 fixedLocalPosition = Vector3.zero; // Center of the container
        // Or specify specific coordinates within bounds:
        // e.g., new Vector3(0.2f, 0.1f, -0.3f)

        handInstance.transform.localPosition = fixedLocalPosition;

        // Assign to currentHand
        currentHand = handInstance;
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
        isAnimating = false;
        if (currentHand != null)
        {
            AddSpinComponent();
        }
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
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }
}