using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [HideInInspector] public bool pop;
    private Material thisMaterial;

    private RaycastHit hitInfo;
    private float distance;
    private float distance1;
    private float distance2;
    private float closestGrid;
    private bool notOnGrid;
    private bool downEmpty;
    private int closestY;

    [SerializeField] private bool isCage;
    
    [SerializeField] private AudioClip BoxPop;
    [SerializeField] private AudioClip CagePop;
    [SerializeField] private GameObject soundEffect;
    

    private void Start() {

        thisMaterial = GetComponent<MeshRenderer>().material;
        pop = false;
        

        
        
    }
    private void Update() {

        if(!isCage)
        {
            AutomaticPhysics();
        }
        
        
        if(pop)
        {
            
            //var replacement = Instantiate(_replacement,transform.position,transform.rotation);
            BoxSoundEffect();
            var replacement = ObjectPoolerBrokenCubes.Instance.GetObject(transform.position, transform.rotation);
            var mrs = replacement.GetComponentsInChildren<MeshRenderer>();
            
            foreach (var mat in mrs)
            {
                mat.material.color = thisMaterial.color;
            }

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

    private void BoxSoundEffect()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {

                if (!Selector.boxSoundEffectCast)
                {
                    var sound_effect = Instantiate(soundEffect);

                    if(isCage)
                    {
                        sound_effect.GetComponent<AudioSource>().PlayOneShot(CagePop);
                    }
                    else
                    {
                        sound_effect.GetComponent<AudioSource>().PlayOneShot(BoxPop);
                    }
                    
                    Selector.boxSoundEffectCast = true;
                }

            }
        }

       
        
    }
    
}
