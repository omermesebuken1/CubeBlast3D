using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuCamera : MonoBehaviour
{
    [SerializeField] private Vector3 Target;
    [SerializeField] private float heightOffset;
    [SerializeField] private float heightOffsetSpeed;

    [SerializeField] private float heightOffsetMin;
    [SerializeField] private float heightOffsetMax;
    
    
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float targetSpeed;

    [SerializeField] private float maxTargetY;

    [SerializeField] private float minTargetY;

    private float deltaTarget;
    private float deltaHeight;
    
    

    private void Start() {
        
        Target = new Vector3(0,10,0);
        heightOffset = 0;
        deltaTarget = 0.01f;
        deltaHeight = 0.01f;

    }
    
    private void Update() {
        
        transform.RotateAround(Target,new Vector3(0,1,0),1*rotateSpeed*Time.deltaTime);

        transform.LookAt(Target);

        transform.position = new Vector3(transform.position.x,Target.y + heightOffset,transform.position.z);


        if(Target.y > maxTargetY)
        {
            deltaTarget = -0.01f;
        }
        if(Target.y < minTargetY)
        {
            deltaTarget = 0.01f;
        }
        
        Target.y += deltaTarget*targetSpeed*Time.deltaTime;


        if(heightOffset > heightOffsetMax)
        {
            deltaHeight = -0.01f;
        }
        if(heightOffset < heightOffsetMin)
        {
            deltaHeight = 0.01f;
        }

        heightOffset += deltaHeight*heightOffsetSpeed*Time.deltaTime;
        

    }

}
