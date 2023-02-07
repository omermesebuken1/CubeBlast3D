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

    [SerializeField] private GameObject Diag;

    [SerializeField] private GameObject DiagOn;
    [SerializeField] private GameObject DiagOff;



    private void Start()
    {
        Panel.SetActive(false);
        SettingsTouchBlocker.SetActive(false);
        SettingsIcon.SetActive(true);
        CloseDiag();

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
    



}
