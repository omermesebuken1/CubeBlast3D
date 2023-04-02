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

    [SerializeField] private AudioClip SoftCubePop;

    [SerializeField] private GameObject soundEffect;

    private bool softCubeSoundEffectCast;
    
    static public bool boxSoundEffectCast;

    Vibrator vibrator;

    private void Start() {

        vibrator = FindObjectOfType<Vibrator>();
    }
    



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
                    softCubeSoundEffectCast = false;
                    boxSoundEffectCast = false;


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
                            if (FindObjectOfType<GamePlay>() != null)
                            {
                                FindObjectOfType<GamePlay>().moveUsed = true;
                            }
                            FindObjectOfType<PopCounter>().countPops = true;
                            FindObjectOfType<PopCounter>().countBoxes = true;
                            hitObject.GetComponent<Cube>().pop = true;
                            FindObjectOfType<PopCounter>().lastTouched = hitObject;
                            SoftCubeSoundEffect();
                            vibrator.VibrateHard();


                        }

                        if (hitObject.transform.CompareTag("Rocket"))
                        {
                            hitObject.GetComponent<Rocket>().pop = true;
                            FindObjectOfType<PopCounter>().countPops = false;
                            FindObjectOfType<PopCounter>().countBoxes = true;
                            if (FindObjectOfType<GamePlay>() != null)
                            {
                                FindObjectOfType<GamePlay>().moveUsed = true;
                            }
                        }

                        if (hitObject.transform.CompareTag("Bomb"))
                        {
                            hitObject.GetComponent<Bomb>().pop = true;
                            FindObjectOfType<PopCounter>().countPops = false;
                            FindObjectOfType<PopCounter>().countBoxes = true;
                            if (FindObjectOfType<GamePlay>() != null)
                            {
                                FindObjectOfType<GamePlay>().moveUsed = true;
                            }
                        }

                        if (hitObject.transform.CompareTag("Laser"))
                        {
                            hitObject.GetComponent<Laser>().pop = true;
                            FindObjectOfType<PopCounter>().countPops = false;
                            FindObjectOfType<PopCounter>().countBoxes = true;
                            if (FindObjectOfType<GamePlay>() != null)
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

    private void SoftCubeSoundEffect()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {

                if (!softCubeSoundEffectCast)
                {
                    var sound_effect = Instantiate(soundEffect);
                    
                    sound_effect.GetComponent<AudioSource>().pitch = 0.5f;
                    sound_effect.GetComponent<AudioSource>().volume = 0.3f;
                    sound_effect.GetComponent<AudioSource>().PlayOneShot(SoftCubePop);
                    softCubeSoundEffectCast = true;
                }

            }
        }
    }

    

    

}

