using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float transitionTime = 4f;
    //private ButtonAnimation ButtonAnimation;

    //public static SceneLoader instance;

    //private void Awake(){
    //    if(instance == null){
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else{
    //        Destroy(gameObject);
    //    }
        
    //}

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
        //Debug.Log("2");
        //ButtonAnimation = GetComponent<ButtonAnimation>();
        //Debug.Log("3");
        //ButtonAnimation.switchButton();
        //Debug.Log("time started");
        yield return new WaitForSeconds(transitionTime);
        //Debug.Log("time ended");
        SceneManager.LoadScene(sceneToLoad);
    }
}
