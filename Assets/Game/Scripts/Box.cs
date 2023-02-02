using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [HideInInspector] public bool pop;
    private Material thisMaterial;


    private void Start() {

        thisMaterial = GetComponent<MeshRenderer>().material;
        pop = false;
    }
    private void Update() {

        AutomaticPhysics();
        
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
