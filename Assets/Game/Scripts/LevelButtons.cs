using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{

    private string levelNumber;
    [SerializeField] private TextMeshProUGUI buttonText;

    // Level (1)
    private void Start() {
        
        levelNumber = gameObject.name;

        levelNumber = levelNumber.Replace("Level (", string.Empty);
        levelNumber = levelNumber.Replace(")", string.Empty);

        
        buttonText.text = levelNumber;
    }

    public void GoToScene()
    {
        
            FindObjectOfType<LevelManager>().LoadScene(levelNumber);
        
    }
    
}
