using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private AudioClip ButtonClick1;
    [SerializeField] private AudioClip ButtonClick2;
    [SerializeField] private bool SoundChoice;
    private bool ButtonClickSoundEffectCast;

    
   
    public void ButtonSoundEffect()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {

                
                    if(SoundChoice == true)
                    {
                        GetComponent<AudioSource>().volume = 1f;
                        GetComponent<AudioSource>().PlayOneShot(ButtonClick1);
                        ButtonClickSoundEffectCast = true;
                    }
                    else
                    {
                        GetComponent<AudioSource>().volume = 1f;
                        GetComponent<AudioSource>().PlayOneShot(ButtonClick2);
                        ButtonClickSoundEffectCast = true;
                    }
                        
                    
                

                

            }
        }
    }

}
