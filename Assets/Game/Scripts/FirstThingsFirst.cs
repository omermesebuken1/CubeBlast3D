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

                if(i == 1 || i == 26 || i == 51 || i == 76)
                {
                    PlayerPrefs.SetString("L" + i.ToString(),"Unlocked");
                }


            }
        }


        PlayerPrefs.SetFloat("CamSensi",33f);
        PlayerPrefs.SetInt("Sound",1);
        PlayerPrefs.SetInt("Vibration",1);


    }


}
