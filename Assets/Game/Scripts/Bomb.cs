using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bomb : MonoBehaviour
{
    private Collider[] objects;
    [SerializeField] private GameObject Effect1;

    [SerializeField] private GameObject Effect2;

    [SerializeField] private float bombArea;

    [HideInInspector] public bool pop;

    private RaycastHit hitInfo;
    private float distance;
    private float distance1;
    private float distance2;
    private float closestGrid;
    private bool notOnGrid;
    private bool downEmpty;
    private int closestY;

    Vibrator vibrator;


    [SerializeField] private AudioClip BombPop;

    [SerializeField] private GameObject soundEffect;
    private bool bombSoundEffectCast;

    private void Start() {

        vibrator = FindObjectOfType<Vibrator>();
        
    }


    private void Update()
    {

        objects = Physics.OverlapSphere(transform.position, bombArea, ManualGravity.instance.cubeLayer);
        
        Explode();

        AutomaticPhysics();
        
    }

    public void Explode()
    {
        if (pop)
        {
            
            foreach (var item in objects)
            {

                if (item.gameObject.CompareTag("Cube"))
                {

                    item.GetComponent<Cube>().popWithoutChain = true;
                }

                if (item.gameObject.CompareTag("Box"))
                {
                    item.GetComponent<Box>().pop = true;
                }

                if (item.gameObject.CompareTag("Rocket"))
                {
                    item.GetComponent<Rocket>().pop = true;
                }

                if (item.gameObject.CompareTag("Bomb") && item.transform.gameObject != this.gameObject)
                {
                    item.GetComponent<Bomb>().pop = true;
                }

                if (item.gameObject.CompareTag("Laser"))
                {
                    item.GetComponent<Laser>().pop = true;
                }

            }

            Instantiate(Effect1, transform.position, transform.rotation);
            Instantiate(Effect2, transform.position, transform.rotation);
            BombSoundEffect();
            vibrator.VibrateHard();
            pop = false;
            Destroy(this.gameObject);

        }


    }


    private void AutomaticPhysics()
    {
        if (Physics.Raycast(transform.position, -transform.up, out hitInfo, ManualGravity.instance.raycastLength, ManualGravity.instance.cubeLayer))
        {
            
            downEmpty = false;
        }
        else
        {
            
            downEmpty = true;
        }
        if (downEmpty)
        {
            transform.Translate(0,-ManualGravity.instance.gravitySpeed * Time.deltaTime,0);
        }
        else
        {
            if (transform.position.y % 2.05 != 0)
            {
                notOnGrid = true;

            }
            if (notOnGrid)
            {
                goToClosestGrid();

            }
        }

    }

    private float FindClosestGrid()
    {

        closestY = Mathf.FloorToInt(transform.position.y / 2.05f);

        distance1 = Mathf.Abs(transform.position.y - closestY * 2.05f);
        distance2 = Mathf.Abs(transform.position.y - (closestY + 1) * 2.05f);

        if (distance2 >= distance1)
        {
            closestGrid = closestY * 2.05f;
            return closestGrid;
        }
        else
        {
            closestGrid = (closestY + 1) * 2.05f;
            return closestGrid;
        }


    }

    private void goToClosestGrid()
    {
        if (transform.position.y % 2.05 != 0)
        {
            float newY = FindClosestGrid();
            
            Vector3 target = new Vector3(transform.position.x, newY, transform.position.z);

            distance = Mathf.Abs(transform.position.y - newY);
            

            if (distance < 0.1f)
            {
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target, 2*ManualGravity.instance.gravitySpeed * Time.deltaTime);

            }

        }

    }

    private void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.CompareTag("Cube"))
        {
            other.transform.GetComponent<Cube>().popWithoutChain = true;
        }

        if (other.gameObject.CompareTag("Box"))
        {
            other.transform.GetComponent<Box>().pop = true;
        }

        if (other.gameObject.CompareTag("Rocket"))
        {
            other.transform.GetComponent<Rocket>().pop = true;
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            other.transform.GetComponent<Bomb>().pop = true;
        }

        if (other.gameObject.CompareTag("Laser"))
        {
            other.transform.GetComponent<Laser>().pop = true;
        }

    }

    private void BombSoundEffect()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {

                if (!bombSoundEffectCast)
                {
                    var sound_effect = Instantiate(soundEffect);
                    sound_effect.GetComponent<AudioSource>().PlayOneShot(BombPop);
                    bombSoundEffectCast = true;
                }

            }
        }
        
        
        
    }    


    
    
    



}
