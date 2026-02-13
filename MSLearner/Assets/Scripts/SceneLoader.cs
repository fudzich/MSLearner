using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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
        SceneManager.LoadScene("ASLToEnglish");
    }

    public void LoadASLTranslator()
    {
        SceneManager.LoadScene("ASLTranslator");
    }

    public void LoadEnglishToASL()
    {
        SceneManager.LoadScene("EnglishToASL");
    }

    public void LoadLearningMaterials()
    {
        SceneManager.LoadScene("LearningMaterials");
    }

    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            // Quit the application
            Application.Quit();
            #endif
    }
}
