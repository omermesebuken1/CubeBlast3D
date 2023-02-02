using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [HideInInspector] public bool pop;
    [SerializeField] private GameObject rocketUstPrefab;
    [SerializeField] private GameObject rocketAltPrefab;

    
   
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

        if(Physics.Raycast(transform.position,-transform.up,ManualGravity.instance.raycastLength,ManualGravity.instance.cubeLayer))
        {
            transform.Translate(new Vector3(0,0,0));
        }
        else
        {
            transform.Translate(-transform.up*Time.deltaTime*ManualGravity.instance.gravitySpeed);
        }

        

    }

    

}
