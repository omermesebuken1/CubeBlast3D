using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;

    [Range(-60f, -5f)][SerializeField] private float distanceFromTarget;

    private Touch touch;

    private Vector3 previousPosition;

    private float camLastDistanceBetweenTarget;

    private bool touchEnabled;

    [SerializeField] private float CameraUpDownSensivity;

    [SerializeField] private float CameraRotationSensivity;

    [SerializeField] private float CameraMinHeight;

    [SerializeField] private float CameraMaxHeight;

    [SerializeField] private Vector3 CameraOffset;

    [SerializeField] private float targetStartPosition;

    public float cameraGeneralSensivity = 1f;


    private void Start() {
        
        touchEnabled = true;
        target.position = new Vector3(target.position.x, targetStartPosition, target.position.z);
        cam.transform.position = new Vector3(cam.transform.position.x, target.position.y, cam.transform.position.z);
        
    }

    
    private void Update()
    {
        
        UITouchChecker();

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touchEnabled)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    previousPosition = cam.ScreenToViewportPoint(touch.position);
                }

                if (touch.phase == TouchPhase.Moved)
                {

                    Vector3 direction = previousPosition - cam.ScreenToViewportPoint(touch.position);

                    cam.transform.LookAt(target);

                    target.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y + direction.y*cameraGeneralSensivity*CameraUpDownSensivity*Time.deltaTime,CameraMinHeight,CameraMaxHeight), target.position.z);

                    cam.transform.rotation *= Quaternion.Euler(CameraOffset);

                    cam.transform.RotateAround(target.position,new Vector3(0,-1,0),cameraGeneralSensivity*CameraRotationSensivity*direction.x*Time.deltaTime);
                    
                    cam.transform.position = new Vector3(cam.transform.position.x, target.position.y, cam.transform.position.z);

                    previousPosition = cam.ScreenToViewportPoint(touch.position);

                     
                }
            }


        }
        

    }


    private void UITouchChecker()
    {
        //Exit if touch is over UI element.
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;

            if (EventSystem.current.IsPointerOverGameObject(id))
            {

                touchEnabled = false;

                return;
            }

            else
            {
                touchEnabled = true;

            }
        }
    }

   



   


   

}
