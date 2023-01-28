using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAlt : MonoBehaviour
{
    [SerializeField] private float speed;

    private float timer;

    [SerializeField] private float lifeTime;

    private void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        

        if (other.gameObject.CompareTag("Cube"))
        {
            other.GetComponent<Cube>().popWithoutChain = true;
        }

        if (other.gameObject.CompareTag("Box"))
        {
            other.GetComponent<Box>().pop = true;
        }

        if (other.gameObject.CompareTag("Rocket"))
        {
            other.GetComponent<Rocket>().pop = true;
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            other.GetComponent<Bomb>().pop = true;
        }

        if (other.gameObject.CompareTag("Laser"))
        {
            other.GetComponent<Laser>().pop = true;
        }
    }
}
