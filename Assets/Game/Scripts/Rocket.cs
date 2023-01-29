using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [HideInInspector] public bool pop;
    [SerializeField] private GameObject rocketUstPrefab;
    [SerializeField] private GameObject rocketAltPrefab;

    [SerializeField] private float raycastLength;
   [SerializeField]  private LayerMask cubeLayer;
   
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

        if(Physics.Raycast(transform.position,-transform.up,raycastLength,cubeLayer))
        {
            transform.Translate(new Vector3(0,0,0));
        }
        else
        {
            transform.Translate(-transform.up*Time.deltaTime);
        }

    }

}
