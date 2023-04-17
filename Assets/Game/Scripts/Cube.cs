using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IPooledObject
{


    private Material thisMetarial;
    private int rand;
     GameObject[] touchingObject = new GameObject[6];
    public bool selectable;
    [HideInInspector] public bool pop;
    [HideInInspector] public bool popWithoutChain;
    [SerializeField] private GameObject _replacement;

    private RaycastHit hitInfo;
    private float distance;
    private float distance1;
    private float distance2;
    private float closestGrid;
    private bool notOnGrid;
    private bool downEmpty;
    private int closestY;
     public bool isMoving;



    public void OnObjectSpawn()
    {

        pop = false;
        popWithoutChain = false;
        thisMetarial = GetComponent<MeshRenderer>().material;
        SetMetarial();

        for (int i = 0; i < touchingObject.Length; i++)
        {
            touchingObject[i] = null;
        }


    }

    private void Start()
    {

        thisMetarial = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if (!isMoving)
        {
            ConnectionChecker();

            PopChain();
        }

        AutomaticPhysics();

    }


    private void ConnectionChecker()
    {

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 2))
        {
            if (hitInfo.transform.CompareTag("Cube") || hitInfo.transform.CompareTag("Box"))
            {

                touchingObject[0] = hitInfo.transform.gameObject;
            }

        }
        else
        {
            touchingObject[0] = null;
        }

        if (Physics.Raycast(transform.position, -transform.forward, out hitInfo, 2))
        {
            if (hitInfo.transform.CompareTag("Cube") || hitInfo.transform.CompareTag("Box"))
            {

                touchingObject[1] = hitInfo.transform.gameObject;

            }

        }
        else
        {
            touchingObject[1] = null;
        }

        if (Physics.Raycast(transform.position, transform.right, out hitInfo, 2))
        {
            if (hitInfo.transform.CompareTag("Cube") || hitInfo.transform.CompareTag("Box"))
            {

                touchingObject[2] = hitInfo.transform.gameObject;
            }

        }
        else
        {
            touchingObject[2] = null;
        }

        if (Physics.Raycast(transform.position, -transform.right, out hitInfo, 2))
        {
            if (hitInfo.transform.CompareTag("Cube") || hitInfo.transform.CompareTag("Box"))
            {

                touchingObject[3] = hitInfo.transform.gameObject;
            }

        }
        else
        {
            touchingObject[3] = null;
        }


        if (Physics.Raycast(transform.position, transform.up, out hitInfo, 2))
        {
            if (hitInfo.transform.CompareTag("Cube") || hitInfo.transform.CompareTag("Box"))
            {

                touchingObject[4] = hitInfo.transform.gameObject;
            }

        }
        else
        {
            touchingObject[4] = null;
        }

        if (Physics.Raycast(transform.position, -transform.up, out hitInfo, 2))
        {
            if (hitInfo.transform.CompareTag("Cube") || hitInfo.transform.CompareTag("Box"))
            {

                touchingObject[5] = hitInfo.transform.gameObject;
            }

        }
        else
        {
            touchingObject[5] = null;
        }




    }

    private void PopChain()
    {
        if (pop)
        {
            if (touchingObject[0] != null)
            {
                if (touchingObject[0].CompareTag("Box"))
                {
                    touchingObject[0].GetComponentInParent<Box>().pop = true;
                }
                if (touchingObject[0].CompareTag("Cube"))
                {
                    if (touchingObject[0].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                    {
                        touchingObject[0].GetComponent<Cube>().pop = true;
                    }
                }
            }

            if (touchingObject[1] != null)
            {
                if (touchingObject[1].CompareTag("Box"))
                {
                    touchingObject[1].GetComponent<Box>().pop = true;
                }
                if (touchingObject[1].CompareTag("Cube"))
                {
                    if (touchingObject[1].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                    {
                        touchingObject[1].GetComponent<Cube>().pop = true;
                    }
                }
            }

            if (touchingObject[2] != null)
            {
                if (touchingObject[2].CompareTag("Box"))
                {
                    touchingObject[2].GetComponent<Box>().pop = true;
                }
                if (touchingObject[2].CompareTag("Cube"))
                {
                    if (touchingObject[2].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                    {
                        touchingObject[2].GetComponent<Cube>().pop = true;
                    }
                }
            }

            if (touchingObject[3] != null)
            {
                if (touchingObject[3].CompareTag("Box"))
                {
                    touchingObject[3].GetComponent<Box>().pop = true;
                }
                if (touchingObject[3].CompareTag("Cube"))
                {
                    if (touchingObject[3].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                    {
                        touchingObject[3].GetComponent<Cube>().pop = true;
                    }
                }
            }

            if (touchingObject[4] != null)
            {
                if (touchingObject[4].CompareTag("Box"))
                {
                    touchingObject[4].GetComponent<Box>().pop = true;
                }
                if (touchingObject[4].CompareTag("Cube"))
                {
                    if (touchingObject[4].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                    {
                        touchingObject[4].GetComponent<Cube>().pop = true;
                    }
                }
            }

            if (touchingObject[5] != null)
            {
                if (touchingObject[5].CompareTag("Box"))
                {
                    touchingObject[5].GetComponent<Box>().pop = true;
                }
                if (touchingObject[5].CompareTag("Cube"))
                {
                    if (touchingObject[5].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                    {
                        touchingObject[5].GetComponent<Cube>().pop = true;
                    }
                }
            }


            if (ObjectPoolerBrokenCubes.Instance != null)
            {
                var replacement = ObjectPoolerBrokenCubes.Instance.GetObject(transform.position, transform.rotation);
                var mrs = replacement.GetComponentsInChildren<MeshRenderer>();
                foreach (var mat in mrs)
                {
                    mat.material.color = thisMetarial.color;
                }

                if(FindObjectOfType<PopCounter>().countPops == true)
                {
                    FindObjectOfType<PopCounter>().popCount++;
                }
                

                if (ObjectPooler.Instance != null)
                {
                    ObjectPooler.Instance.ReturnObject(this.gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }

            }
            else
            {
                var replacement = Instantiate(_replacement, transform.position, transform.rotation);
                var mrs = replacement.GetComponentsInChildren<MeshRenderer>();
                foreach (var mat in mrs)
                {
                    mat.material.color = thisMetarial.color;
                }

                if(FindObjectOfType<PopCounter>().countPops == true)
                {
                    FindObjectOfType<PopCounter>().popCount++;
                }
                
                if (ObjectPooler.Instance != null)
                {
                    ObjectPooler.Instance.ReturnObject(this.gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }

            }






        }

        if (popWithoutChain)
        {
            if (ObjectPoolerBrokenCubes.Instance != null)
            {
                var replacement = ObjectPoolerBrokenCubes.Instance.GetObject(transform.position, transform.rotation);
                var mrs = replacement.GetComponentsInChildren<MeshRenderer>();
                foreach (var mat in mrs)
                {
                    mat.material.color = thisMetarial.color;
                }

                if(FindObjectOfType<PopCounter>().countPops == true)
                {
                    FindObjectOfType<PopCounter>().popCount++;
                }

                if (ObjectPooler.Instance != null)
                {
                    ObjectPooler.Instance.ReturnObject(this.gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }

            }
            else
            {
                var replacement = Instantiate(_replacement, transform.position, transform.rotation);
                var mrs = replacement.GetComponentsInChildren<MeshRenderer>();
                foreach (var mat in mrs)
                {
                    mat.material.color = thisMetarial.color;
                }

                if(FindObjectOfType<PopCounter>().countPops == true)
                {
                    FindObjectOfType<PopCounter>().popCount++;
                }

                if (ObjectPooler.Instance != null)
                {
                    ObjectPooler.Instance.ReturnObject(this.gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }

        }
    }

    public bool isSelectable()
    {
        selectable = false;

        if (touchingObject[0] != null)
        {
            if (touchingObject[0].CompareTag("Cube"))
            {
                if (touchingObject[0].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                {
                    selectable = true;
                }

            }
        }

        if (touchingObject[1] != null)
        {
            if (touchingObject[1].CompareTag("Cube"))
            {
                if (touchingObject[1].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                {
                    selectable = true;
                }

            }
        }

        if (touchingObject[2] != null)
        {
            if (touchingObject[2].CompareTag("Cube"))
            {
                if (touchingObject[2].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                {
                    selectable = true;
                }

            }
        }

        if (touchingObject[3] != null)
        {
            if (touchingObject[3].CompareTag("Cube"))
            {
                if (touchingObject[3].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                {
                    selectable = true;
                }

            }
        }

        if (touchingObject[4] != null)
        {
            if (touchingObject[4].CompareTag("Cube"))
            {
                if (touchingObject[4].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                {
                    selectable = true;
                }

            }
        }

        if (touchingObject[5] != null)
        {
            if (touchingObject[5].CompareTag("Cube"))
            {
                if (touchingObject[5].GetComponent<MeshRenderer>().material.color == thisMetarial.color)
                {
                    selectable = true;
                }

            }
        }

        return selectable;
    }

    public void SetMetarial()
    {
        rand = Random.Range(1, 5);
        switch (rand)
        {
            case 1:
                GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case 2:
                GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case 3:
                GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case 4:
                GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
        }
    }

    public void SetMetarialByChoice(int colorCode)
    {
        switch (colorCode)
        {
            case 1:
                GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case 2:
                GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case 3:
                GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case 4:
                GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
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
            isMoving = true;
        }
        if (downEmpty)
        {

            transform.Translate(0, -ManualGravity.instance.gravitySpeed * Time.deltaTime, 0);

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

        if(transform.position.y <= 0)
        {
            isMoving = false;
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
                isMoving = false;
            }
            else
            {


                transform.position = Vector3.MoveTowards(transform.position, target, 2 * ManualGravity.instance.gravitySpeed * Time.deltaTime);


            }

        }

    }




}
