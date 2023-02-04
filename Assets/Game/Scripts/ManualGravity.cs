using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualGravity: MonoBehaviour
{
    public static ManualGravity instance;

   [SerializeField] public float raycastLength = 1.05f;
   [SerializeField] public LayerMask cubeLayer;
   [SerializeField] public float gravitySpeed;
   [HideInInspector] public Vector3 velocity = Vector3.zero;

   

    private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
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
