using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFiller : MonoBehaviour
{
    [SerializeField] private GameObject CubePrefab;
    [SerializeField] private GameObject BoxPrefab;
   
    ObjectPooler objectPooler;
    private GameObject currentCube;
    [SerializeField] private GameObject theParent;

 


    

    private void Start() {

        objectPooler = ObjectPooler.Instance;

    }

    
    private void Update()
    {

        if (!Physics.CheckSphere(transform.position, 0.5f))
        {

            currentCube = null;
            //currentCube = Instantiate(CubePrefab, transform.position, transform.rotation);
            currentCube = ObjectPooler.Instance.GetObject(transform.position, transform.rotation);
            currentCube.GetComponent<Cube>().SetMetarial();

            currentCube.transform.parent = theParent.transform;

        }


    }



}
