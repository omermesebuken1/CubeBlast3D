using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCounter : MonoBehaviour
{
    [HideInInspector] public int popCount;

    [HideInInspector] public bool refresh;

    [HideInInspector] public bool countPops;
    [HideInInspector] public bool countBoxes;

    private float popTimer;

    private float boxTimer;

    private bool place;

    [HideInInspector] public GameObject lastTouched;

    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private GameObject bombPrefab;

    [SerializeField] private GameObject laserPrefab;

    private bool powerAdded;


    private void Update()
    {
        PopCount();
        BoxCount();
        
    }

    private void AddPowerUp()
    {
        if (!powerAdded)
        {

            if (popCount >= 5 && popCount <= 8)
            {
                Instantiate(laserPrefab, lastTouched.transform.position, lastTouched.transform.rotation);
                //print("Last Pop: " + popCount);
                powerAdded = true;
                countPops = false;
                popCount = 0;
            }

            else if (popCount >= 9 && popCount <= 12)
            {
                Instantiate(rocketPrefab, lastTouched.transform.position, lastTouched.transform.rotation);
                //print("Last Pop: " + popCount);
                powerAdded = true;
                countPops = false;
                popCount = 0;
            }

            else if (popCount >= 13)
            {
                Instantiate(bombPrefab, lastTouched.transform.position, lastTouched.transform.rotation);
                //print("Last Pop: " + popCount);
                powerAdded = true;
                countPops = false;
                popCount = 0;
            }
            else
            {
                //print("Pop: " + popCount);
                countPops = false;
                popCount = 0;
            }

            

        }



    }

    private void PopCount()
    {

        if (refresh)
        {
            popCount = 0;
            refresh = false;
        }

        if (countPops)
        {
            powerAdded = false;
            popTimer += Time.deltaTime;
        }

        if (popTimer > 0.2f)
        {
            countPops = false;
            AddPowerUp();
            refresh = true;
            popTimer = 0;

        }

    }

    private void BoxCount()
    {

        if (countBoxes)
        {
            boxTimer += Time.deltaTime;
        }

        if (boxTimer > 0.4f)
        {
            if (FindObjectOfType<LevelChecker>() != null)
            {
                FindObjectOfType<LevelChecker>().countAgain = true;
            }
            countBoxes = false;
            boxTimer = 0;
        }

    }




}
