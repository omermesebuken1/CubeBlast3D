using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerScript : MonoBehaviour, IPooledObject
{
    private float timer;

    [SerializeField] private float LifeTime;

    [SerializeField] private List<GameObject> particles = new List<GameObject>();

    [SerializeField] private float explosionForce;

    private void Start()
    {

        if (ObjectPoolerBrokenCubes.Instance == null)
        {
            OnObjectSpawn();
        }
    }

    public void OnObjectSpawn()
    {
        timer = 0;

        foreach (GameObject part in particles)
        {
            
            part.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //part.transform.position = part.GetComponent<BrokenParticlesCube>().realPos;
            //part.transform.localScale = new Vector3(100, 100, 100);
            part.GetComponent<Rigidbody>().AddExplosionForce(explosionForce * Random.Range(1, 3f), transform.position, Random.Range(1f, 3f), Random.Range(0, 1f));


        }

    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > LifeTime)
        {
            transform.position = new Vector3(0, 0, 0);

            foreach (GameObject part in particles)
            {
                //part.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                part.transform.rotation = part.GetComponent<BrokenParticlesCube>().realRot;
                part.transform.position = part.GetComponent<BrokenParticlesCube>().realPos;
                part.transform.localScale = new Vector3(100, 100, 100);
                //part.GetComponent<Rigidbody>().AddExplosionForce(explosionForce*Random.Range(0.1f,2f),transform.position,2);

            }
            if (ObjectPoolerBrokenCubes.Instance != null)
            {
                ObjectPoolerBrokenCubes.Instance.ReturnObject(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

        }
    }
}
