using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{

    private string levelNumber;
    private Image image;
    [SerializeField] private TextMeshProUGUI buttonText;

    // Level (1)

    // açık mavi = CBF9FF
    // yeşil = 67FF56
    // bordo = 4B3045

    Color colorMavi;
    Color colorYesil;
    Color colorBordo;

    


    private void Start()
    {
        SetNumbers();
        SetColors();
    }

    public void GoToScene()
    {
         if(PlayerPrefs.HasKey("L" + levelNumber))
        {
        if(PlayerPrefs.GetString("L" + levelNumber) != "Locked")
        {
            FindObjectOfType<LevelManager>().LoadScene(levelNumber);
        }
        }
        
        

    }

    private void SetColors(){

        ColorUtility.TryParseHtmlString("#CBF9FF", out colorMavi);
        ColorUtility.TryParseHtmlString("#67FF56", out colorYesil);
        ColorUtility.TryParseHtmlString("#4B3045", out colorBordo);
        image = gameObject.GetComponent<Image>();

        
        if(PlayerPrefs.HasKey("L" + levelNumber))
        {
        if(PlayerPrefs.GetString("L" + levelNumber) == "Finished")
        {
            image.color = colorYesil;
        }
        else if(PlayerPrefs.GetString("L" + levelNumber) == "Unlocked")
        {
            image.color = colorMavi;
        }
        else if(PlayerPrefs.GetString("L" + levelNumber) == "Locked")
        {
            image.color = colorBordo;
        }
        }
        else
        {
            image.color = colorMavi;
        }
        



    }

    private void SetNumbers()
    {   
        levelNumber = gameObject.name;
        levelNumber = levelNumber.Replace("Level (", string.Empty);
        levelNumber = levelNumber.Replace(")", string.Empty);
        buttonText.text = levelNumber;
    }

}
