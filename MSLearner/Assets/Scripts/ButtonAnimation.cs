using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public GameObject[] buttons;

    //metgod to play UI animation
    public void switchButton(){
        foreach(GameObject button in buttons)
        {
            if (button != null)
            {
                Animator animator = button.GetComponent<Animator>();
                if(animator != null)
                {
                    bool slide = animator.GetBool("switch");
                    animator.SetBool("switch", !slide);
                }
            }
        }
        
    }
    
}
