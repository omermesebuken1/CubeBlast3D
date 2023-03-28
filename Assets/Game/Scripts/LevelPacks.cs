using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPacks : MonoBehaviour
{

    [SerializeField] private GameObject Lock1;
    [SerializeField] private GameObject Lock2;
    [SerializeField] private GameObject Lock3;

    private void Start()
    {

        

        if (!PlayerPrefs.HasKey("Pack1"))
        {
            PlayerPrefs.SetInt("Pack1", 0);
        }
        if (!PlayerPrefs.HasKey("Pack2"))
        {
            PlayerPrefs.SetInt("Pack2", 0);
        }
        if (!PlayerPrefs.HasKey("Pack3"))
        {
            PlayerPrefs.SetInt("Pack3", 0);
        }

        Lock1.SetActive(true);
        Lock2.SetActive(true);
        Lock3.SetActive(true);

    }


    private void Update()
    {

        if (PlayerPrefs.HasKey("Pack1"))
        {
            if (PlayerPrefs.GetInt("Pack1") == 1)
            {
                Lock1.SetActive(false);
            }
        }

        if (PlayerPrefs.HasKey("Pack2"))
        {
            if (PlayerPrefs.GetInt("Pack2") == 1)
            {
                Lock2.SetActive(false);
            }
        }

        if (PlayerPrefs.HasKey("Pack3"))
        {
            if (PlayerPrefs.GetInt("Pack3") == 1)
            {
                Lock3.SetActive(false);
            }
        }

    }


    public void Pack1Bought()
    {
        PlayerPrefs.SetInt("Pack1", 1);
    }

    public void Pack2Bought()
    {
        PlayerPrefs.SetInt("Pack2", 1);
    }

    public void Pack3Bought()
    {
        PlayerPrefs.SetInt("Pack3", 1);
    }
}
