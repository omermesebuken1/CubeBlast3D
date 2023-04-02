using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    
    [SerializeField] private List<AudioClip> buttonSound = new List<AudioClip>();
    
    
    private bool ButtonClickSoundEffectCast;

    Vibrator vibrator;

    private void Start() {

        
        vibrator = FindObjectOfType<Vibrator>();
    }

    
   
    public void ButtonSoundEffect(int SoundChoice)
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {

                
                    if(SoundChoice == 0)
                    {
                        GetComponent<AudioSource>().volume = 1f;
                        GetComponent<AudioSource>().PlayOneShot(buttonSound[0]);
                        ButtonClickSoundEffectCast = true;
                        vibrator.VibrateLight();
                    }
                    else if(SoundChoice == 1)
                    {
                        GetComponent<AudioSource>().volume = 1f;
                        GetComponent<AudioSource>().PlayOneShot(buttonSound[1]);
                        ButtonClickSoundEffectCast = true;
                        vibrator.VibrateLight();
                    }
                    else if(SoundChoice == 2)
                    {
                        GetComponent<AudioSource>().volume = 1f;
                        GetComponent<AudioSource>().PlayOneShot(buttonSound[2]);
                        ButtonClickSoundEffectCast = true;
                        vibrator.VibrateLight();
                    }
                        
                    
                

                

            }
        }
    }

}
