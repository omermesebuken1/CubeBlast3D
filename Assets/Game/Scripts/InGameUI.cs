using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{

    [SerializeField] private Slider camSensSlider;

    [SerializeField] private GameObject Panel;

    [SerializeField] private GameObject SettingsTouchBlocker;

    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private GameObject SettingsIcon;

    [SerializeField] private GameObject Diag;
    [SerializeField] private GameObject DiagOn;
    [SerializeField] private GameObject DiagOff;

    
    [SerializeField] private GameObject SoundOn;
    [SerializeField] private GameObject SoundOff;

    
    [SerializeField] private GameObject VibrationOn;
    [SerializeField] private GameObject VibrationOff;

    private bool levelTextWritten;


    private void Start()
    {
        Panel.SetActive(false);
        SettingsTouchBlocker.SetActive(false);
        SettingsIcon.SetActive(true);
        DeactivateDiag();
        SoundStart();
        VibrationStart();
        levelTextWritten = false;
        if(PlayerPrefs.HasKey("CamSensi"))
        {
            camSensSlider.value = PlayerPrefs.GetFloat("CamSensi");
        }
        camSensSlider.value = PlayerPrefs.GetFloat("CamSensi");
        FindObjectOfType<CameraController>().cameraGeneralSensivity = camSensSlider.value / 50;
    }



    private void Update()
    {
        if(FindObjectOfType<GamePlay>().activeSceneNumberChecked && !levelTextWritten)
        {
            levelText.text = "LEVEL " + FindObjectOfType<GamePlay>().activeSceneNumber;
            levelTextWritten = true;
        }

        if (FindObjectOfType<CameraController>())
        {

            FindObjectOfType<CameraController>().cameraGeneralSensivity = camSensSlider.value / 50;
            PlayerPrefs.SetFloat("CamSensi",camSensSlider.value);
        }
    }

    public void CloseSettings()
    {

        Panel.SetActive(false);
        SettingsTouchBlocker.SetActive(false);
        SettingsIcon.SetActive(true);

    }

    public void OpenSettings()
    {

        Panel.SetActive(true);
        SettingsTouchBlocker.SetActive(true);
        SettingsIcon.SetActive(false);

    }

    public void OpenDiag()
    {

        Diag.SetActive(true);
        DiagOff.SetActive(false);
        DiagOn.SetActive(true);

    }

    public void CloseDiag()
    {

        Diag.SetActive(false);
        DiagOff.SetActive(true);
        DiagOn.SetActive(false);

    }

    private void DeactivateDiag()
    {
        Diag.SetActive(false);
        DiagOff.SetActive(false);
        DiagOn.SetActive(false);

    }

    private void SoundStart()
    {
        if(PlayerPrefs.HasKey("Sound"))
        {
            if(PlayerPrefs.GetInt("Sound") == 1)
            {
                SoundOn.SetActive(true);
                SoundOff.SetActive(false);
            }
            else
            {
                SoundOn.SetActive(false);
                SoundOff.SetActive(true);
            }
        }
        
    }

    public void CloseSound()
    {
        SoundOn.SetActive(false);
        SoundOff.SetActive(true);
        PlayerPrefs.SetInt("Sound",0);
    }

    public void OpenSound()
    {
        SoundOn.SetActive(true);
        SoundOff.SetActive(false);
        PlayerPrefs.SetInt("Sound",1);
    }

    private void VibrationStart()
    {
        if(PlayerPrefs.HasKey("Vibration"))
        {
            if(PlayerPrefs.GetInt("Vibration") == 1)
            {
                VibrationOn.SetActive(true);
                VibrationOff.SetActive(false);
            }
            else
            {
                VibrationOn.SetActive(false);
                VibrationOff.SetActive(true);
            }
        }
        
    }

    public void CloseVibration()
    {
        VibrationOn.SetActive(false);
        VibrationOff.SetActive(true);
        PlayerPrefs.SetInt("Vibration",0);
    }

    public void OpenVibration()
    {
        VibrationOn.SetActive(true);
        VibrationOff.SetActive(false);
        PlayerPrefs.SetInt("Vibration",1);
    }

    



}
