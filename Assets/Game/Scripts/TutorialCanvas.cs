using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    
    private void Start() 
    {
        this.gameObject.SetActive(true);
    }

    public void CloseTutorial()
    {
        this.gameObject.SetActive(false);
    }


}
