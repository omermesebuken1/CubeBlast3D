using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour
{
    private Touch touch;

    private GameObject hitObject;

    private RaycastHit hitInfo;

    [SerializeField] private new Camera camera;

    [SerializeField] private LayerMask CubeLayer;

    private bool touchEnabled;



    private void Update()
    {
        UITouchChecker();
        TouchedObjectChecker();

    }

    private void TouchedObjectChecker()
    {

        if (touchEnabled)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {

                    Ray ray = camera.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, CubeLayer))
                    {
                        if (hitInfo.collider.gameObject.GetComponent<Cube>() != null)
                        {
                            if (hitInfo.collider.gameObject.GetComponent<Cube>().isSelectable() && !hitInfo.collider.gameObject.GetComponent<Cube>().isMoving)
                            {
                                hitObject = hitInfo.collider.gameObject;

                            }

                        }
                        if (hitInfo.collider.gameObject.GetComponent<Rocket>() != null)
                        {

                            hitObject = hitInfo.collider.gameObject;

                        }

                        if (hitInfo.collider.gameObject.GetComponent<Bomb>() != null)
                        {

                            hitObject = hitInfo.collider.gameObject;

                        }

                        if (hitInfo.collider.gameObject.GetComponent<Laser>() != null)
                        {

                            hitObject = hitInfo.collider.gameObject;

                        }

                        if (hitInfo.collider.gameObject.CompareTag("Glass"))
                        {

                            hitObject = hitInfo.collider.gameObject;

                        }

                    }
                }

                if (touch.phase == TouchPhase.Moved)
                {

                    hitObject = null;


                }

                if (touch.phase == TouchPhase.Ended)
                {

                    if (hitObject != null)
                    {

                        if (hitObject.transform.CompareTag("Cube"))
                        {
                            if(FindObjectOfType<GamePlay>() != null)
                            {
                                FindObjectOfType<GamePlay>().moveUsed = true;
                            }
                            FindObjectOfType<PopCounter>().countPops = true;
                            FindObjectOfType<PopCounter>().countBoxes = true;
                            hitObject.GetComponent<Cube>().pop = true;
                            FindObjectOfType<PopCounter>().lastTouched = hitObject;
                        }

                        if (hitObject.transform.CompareTag("Rocket"))
                        {
                            hitObject.GetComponent<Rocket>().pop = true;
                            FindObjectOfType<PopCounter>().countBoxes = true;
                            if(FindObjectOfType<GamePlay>() != null)
                            {
                                FindObjectOfType<GamePlay>().moveUsed = true;
                            }
                        }

                        if (hitObject.transform.CompareTag("Bomb"))
                        {
                            hitObject.GetComponent<Bomb>().pop = true;
                            FindObjectOfType<PopCounter>().countBoxes = true;
                            if(FindObjectOfType<GamePlay>() != null)
                            {
                                FindObjectOfType<GamePlay>().moveUsed = true;
                            }
                        }

                        if (hitObject.transform.CompareTag("Laser"))
                        {
                            hitObject.GetComponent<Laser>().pop = true;
                            FindObjectOfType<PopCounter>().countBoxes = true;
                            if(FindObjectOfType<GamePlay>() != null)
                            {
                                FindObjectOfType<GamePlay>().moveUsed = true;
                            }
                        }

                        hitObject = null;
                    }
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

