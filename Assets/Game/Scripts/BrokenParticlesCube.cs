using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenParticlesCube : MonoBehaviour
{
    private float timer;

    [HideInInspector] public Vector3 realPos;
    [HideInInspector] public Quaternion realRot;

    private Vector3 scaleDownVector = new Vector3(1,1,1);
    

    private void Start() {
        
        realPos = transform.localPosition;
        realRot = transform.localRotation;

    }

    private void FixedUpdate()
    {

        
        
        transform.localScale -= scaleDownVector;
    
    }
}
