using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
   
    private float timer;
    [SerializeField] private float LifeTime;


    private void Update() {

        timer += Time.deltaTime;

        if(timer > LifeTime)
        {
            Destroy(this.gameObject);
        }

    }

    

}
