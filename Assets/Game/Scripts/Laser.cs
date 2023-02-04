using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Collider[] objects;
   [SerializeField] private GameObject Effect1;

   [HideInInspector] public bool pop;
   [SerializeField] private Vector3 BoxSize;

    private RaycastHit hitInfo;
    private float distance;
    private float distance1;
    private float distance2;
    private float closestGrid;
    private bool notOnGrid;
    private bool downEmpty;
    private int closestY;
   

   private void Update() {

    objects = Physics.OverlapBox(transform.position,BoxSize,transform.rotation,ManualGravity.instance.cubeLayer);
    Explode();

    AutomaticPhysics();

   }

    public void Explode()
    {
        

        if(pop)
        {

            foreach (var item in objects)
        {

            if(item.gameObject.CompareTag("Cube"))
            {
                item.GetComponent<Cube>().popWithoutChain = true;
            }

            if(item.gameObject.CompareTag("Box"))
            {
                item.GetComponent<Box>().pop = true;
            }

            if(item.gameObject.CompareTag("Rocket"))
            {
                item.GetComponent<Rocket>().pop = true;
            }

            if(item.gameObject.CompareTag("Bomb"))
            {
                item.GetComponent<Bomb>().pop = true;
            }

            if(item.gameObject.CompareTag("Laser") && item.transform.gameObject != this.gameObject)
            {
                item.GetComponent<Laser>().pop = true;
            }
            
        }

        Instantiate(Effect1,transform.position,transform.rotation * Quaternion.Euler(90,0,0));
        pop = false;
        Destroy(this.gameObject);

        }

    }

     
    private void AutomaticPhysics()
    {
        if (Physics.Raycast(transform.position, -transform.up, out hitInfo, ManualGravity.instance.raycastLength, ManualGravity.instance.cubeLayer))
        {
            //Debug.DrawRay(transform.position, -transform.up*hitInfo.distance,Color.green);
            downEmpty = false;
        }
        else
        {
            //Debug.DrawRay(transform.position, -transform.up*20f,Color.red);
            downEmpty = true;
        }
        if (downEmpty)
        {
            Vector3 taban = new Vector3(transform.position.x, 0, transform.position.z);
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, transform.position.z), Time.deltaTime);
            transform.position = Vector3.SmoothDamp(transform.position, taban, ref ManualGravity.instance.velocity, ManualGravity.instance.gravitySpeed * Time.deltaTime);
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
            //print("ClosestY: " + closestY + " closestGrid: " + closestGrid + " newY: " + newY);
            Vector3 target = new Vector3(transform.position.x, newY, transform.position.z);

            distance = Mathf.Abs(transform.position.y - newY);
            //print(distance);

            if (distance < 0.1f)
            {
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else
            {
                //transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
                transform.position = Vector3.SmoothDamp(transform.position, target, ref ManualGravity.instance.velocity, ManualGravity.instance.gravitySpeed * Time.deltaTime);

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
   
    private void OnCollisionStay(Collision other)
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
