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
    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private GameObject retryLevelPanel;

    [HideInInspector] public string activeSceneNumber;

    [HideInInspector] public bool activeSceneNumberChecked;


    private int moves;

    [HideInInspector] public bool moveUsed;


    private void Start()
    {

        nextLevelPanel.SetActive(false);
        retryLevelPanel.SetActive(false);
        touchBlocker.SetActive(false);
        boxesFinished.SetActive(false);
        moves = FindObjectOfType<LevelChecker>().hamleSayisi;
        moveCount.text = moves.ToString();
        activeSceneNumberChecked = false;
        checkLevelID();

        

    }

    private void Update()
    {



        boxCount.text = FindObjectOfType<LevelChecker>().boxCount.ToString();

        if (moveUsed)
        {
            if (moves > 0)
            {
                moves -= 1;
                moveCount.text = moves.ToString();
                moveUsed = false;
            }

        }

        if (moves == 0)
        {
            moveCount.text = moves.ToString();
            touchBlocker.SetActive(true);
            retryLevelPanel.SetActive(true);
            //end game
        }

        if (FindObjectOfType<LevelChecker>().boxCount == 0) //game win
        {
            boxesFinished.SetActive(true);
            boxCount.text = "";
            touchBlocker.SetActive(true);
            nextLevelPanel.SetActive(true);

            PlayerPrefs.SetString("L" + PlayerPrefs.GetInt("sceneNumber").ToString(), "Finished");
            PlayerPrefs.SetString("L" + (PlayerPrefs.GetInt("sceneNumber") + 1).ToString(), "Unlocked");

        }


    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {

        if (PlayerPrefs.HasKey("sceneNumber"))
        {
            int newScene = PlayerPrefs.GetInt("sceneNumber") + 1;
            
            if (PlayerPrefs.HasKey("L" + newScene.ToString()))
            {
                FindObjectOfType<LevelManager>().LoadScene(newScene.ToString());
            }
            else
            {
                print(newScene);
                print("scenename is not valid");
            }

        }

    }

    public void checkLevelID()
    {
        if (!activeSceneNumberChecked)
        {
            activeSceneNumber = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetInt("sceneNumber", int.Parse(activeSceneNumber));
            activeSceneNumberChecked = true;
        }

    }

    public void GoToScene(string sceneName)
    {
        FindObjectOfType<LevelManager>().LoadScene(sceneName);
    }

}
