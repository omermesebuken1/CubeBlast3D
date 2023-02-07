using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [HideInInspector] public bool pop;
    [SerializeField] private GameObject rocketUstPrefab;
    [SerializeField] private GameObject rocketAltPrefab;

    private RaycastHit hitInfo;
    private float distance;
    private float distance1;
    private float distance2;
    private float closestGrid;
    private bool notOnGrid;
    private bool downEmpty;
    private int closestY;
    
   
    void Update()
    {
        if(pop)
        {
            Instantiate(rocketUstPrefab,transform.position,transform.rotation);
            Instantiate(rocketAltPrefab,transform.position,transform.rotation);
            pop = false;
            //ObjectPooler.Instance.ReturnObject(this.gameObject);
            Destroy(this.gameObject);
        }
        
        AutomaticPhysics();

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
    
}
