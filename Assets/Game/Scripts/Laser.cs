using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Collider[] objects;
   [SerializeField] private GameObject Effect1;


   [SerializeField] private LayerMask cubeLayer;

   [HideInInspector] public bool pop;

   

   [SerializeField] private Vector3 BoxSize;

   

   private void Update() {

    objects = Physics.OverlapBox(transform.position,BoxSize,transform.rotation,cubeLayer);
    Explode();

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
}
