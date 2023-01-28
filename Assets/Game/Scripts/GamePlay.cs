using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI boxCount;
    [SerializeField] private TextMeshProUGUI moveCount;
    [SerializeField] private GameObject boxesFinished;
    [SerializeField] private GameObject touchBlocker;
    [SerializeField] private GameObject restartButton;

    private int moves;

    [HideInInspector] public bool moveUsed;
    

    private void Start() {

        restartButton.SetActive(false);
        touchBlocker.SetActive(false);
        boxesFinished.SetActive(false);
        moves = 25;
        moveCount.text = moves.ToString();
        
    }
    
    private void Update() {



        boxCount.text = FindObjectOfType<LevelChecker>().boxCount.ToString();

        if(moveUsed)
        {
            if(moves>0)
            {
            moves -= 1;
            moveCount.text = moves.ToString();
            moveUsed = false;
            }
            
        }

        if(moves == 0)
        {
            moveCount.text = moves.ToString();
            touchBlocker.SetActive(true);
            restartButton.SetActive(true);
            //end game
        }

        if(FindObjectOfType<LevelChecker>().boxCount == 0)
        {
            boxesFinished.SetActive(true);
            boxCount.text = "";
            touchBlocker.SetActive(true);
            restartButton.SetActive(true);
        }


    }

     public void ReloadLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


}
