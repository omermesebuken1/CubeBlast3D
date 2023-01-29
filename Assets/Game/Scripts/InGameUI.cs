using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{

    [SerializeField] private Slider camSensSlider;

    [SerializeField] private GameObject Panel;

    [SerializeField] private GameObject SettingsTouchBlocker;

    [SerializeField] private GameObject SettingsIcon;



    private void Start()
    {
        Panel.SetActive(false);
        SettingsTouchBlocker.SetActive(false);
        SettingsIcon.SetActive(true);

    }



    private void Update()
    {

        if (FindObjectOfType<CameraController>())
        {

            FindObjectOfType<CameraController>().cameraGeneralSensivity = camSensSlider.value / 50;

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



}
