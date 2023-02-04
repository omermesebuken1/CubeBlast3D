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


}
