using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float transitionTime = 4f; // time to wait for animation of UI to fully play

    public void LoadASLToEnglish()
    {
        StartCoroutine(TransitionAndLoadScene("ASLToEnglish"));
    }

    public void LoadASLTranslator()
    {
        StartCoroutine(TransitionAndLoadScene("ASLTranslator"));
    }

    public void LoadEnglishToASL()
    {
        StartCoroutine(TransitionAndLoadScene("EnglishToASL"));
    }

    public void LoadLearningMaterials()
    {
        StartCoroutine(TransitionAndLoadScene("LearningMaterials"));
    }

    public void LoadSampleScene()
    {
        StartCoroutine(TransitionAndLoadScene("SampleScene"));
    }

    public void Exit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            // Quit the application
            Application.Quit();
            #endif
    }

    IEnumerator TransitionAndLoadScene(string sceneToLoad)
    {
        // Wait for animation to finish
        yield return new WaitForSeconds(transitionTime);
        // Load the chosen scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
