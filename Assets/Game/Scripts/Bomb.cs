using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
   private Collider[] objects;
   [SerializeField] private GameObject Effect1;

   [SerializeField] private GameObject Effect2;

   [SerializeField] private LayerMask cubeLayer;

   [SerializeField] private float bombArea;

   [HideInInspector] public bool pop;
   private void Update() {

    objects = Physics.OverlapSphere(transform.position,bombArea,cubeLayer);
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

            if(item.gameObject.CompareTag("Bomb") && item.transform.gameObject != this.gameObject)
            {
                item.GetComponent<Bomb>().pop = true;
            }

            if(item.gameObject.CompareTag("Laser"))
            {
                item.GetComponent<Laser>().pop = true;
            }
            
        }

        Instantiate(Effect1,transform.position,transform.rotation);
        Instantiate(Effect2,transform.position,transform.rotation);
        pop = false;
        Destroy(this.gameObject);

        }
        
        
    }
}
