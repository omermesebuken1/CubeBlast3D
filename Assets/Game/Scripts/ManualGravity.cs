using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualGravity: MonoBehaviour
{
    public static ManualGravity instance;

   [SerializeField] public float raycastLength = 1.05f;
   [SerializeField] public LayerMask cubeLayer;
   [SerializeField] public float gravitySpeed;
   

   

    void Awake() 
{ 
    
     QualitySettings.vSyncCount = 1;
     Application.targetFrameRate = 60;
     
 
    
    if (instance != null && instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        instance = this; 
    } 
}


}
