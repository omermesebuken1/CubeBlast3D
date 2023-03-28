using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstThingsFirst : MonoBehaviour
{

    void Start()
    {


        for (int i = 1; i <= 100; i++)
        {
            if (!PlayerPrefs.HasKey("L" + i.ToString()))
            {
                
                PlayerPrefs.SetString("L" + i.ToString(),"Locked");

                if(i == 1 || i == 25 || i == 50 || i == 75)
                {
                    PlayerPrefs.SetString("L" + i.ToString(),"Unlocked");
                }


            }
        }










    }


}
