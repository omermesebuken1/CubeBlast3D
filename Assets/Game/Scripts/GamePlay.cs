using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI boxCount;
    [SerializeField] private TextMeshProUGUI moveCount;
    [SerializeField] private TextMeshProUGUI boxCount2;
    [SerializeField] private TextMeshProUGUI moveCount2;

    [SerializeField] private GameObject boxesFinished;
    [SerializeField] private GameObject boxesFinished2;
    [SerializeField] private GameObject touchBlocker;
    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private GameObject retryLevelPanel;

    [HideInInspector] public string activeSceneNumber;

    [HideInInspector] public bool activeSceneNumberChecked;


    private int moves;

    [HideInInspector] public bool moveUsed;

    [SerializeField] private AudioClip GameWinSoundEffect;
    [SerializeField] private AudioClip GameLoseSoundEffect;
    private bool GameEndSoundEffectCast;
    private int GameStatus;
    private float gameEndTimer;

    [SerializeField] private float gameEndTimerLimit;


    private void Start()
    {
        GameStatus = 0;
        nextLevelPanel.SetActive(false);
        retryLevelPanel.SetActive(false);
        touchBlocker.SetActive(false);
        boxesFinished.SetActive(false);
        boxesFinished2.SetActive(false);
        moves = FindObjectOfType<LevelChecker>().hamleSayisi;
        moveCount.text = moves.ToString();
        activeSceneNumberChecked = false;
        checkLevelID();



    }

    private void Update()
    {

        boxCount2.text = boxCount.text;
        moveCount2.text = moveCount.text;

        GameEndTimer();

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

        if (moves == 0 && FindObjectOfType<LevelChecker>().boxCount != 0) //game lose
        {
            GameStatus = -1;
            moveCount.text = moves.ToString();
            touchBlocker.SetActive(true);

            if (gameEndTimer > gameEndTimerLimit)
            {
                retryLevelPanel.SetActive(true);
                GameStatusSoundEffect();
            }



        }

        if (FindObjectOfType<LevelChecker>().boxCount == 0) //game win
        {
            GameStatus = 1;
            retryLevelPanel.SetActive(false);
            boxesFinished.SetActive(true);
            boxesFinished2.SetActive(true);
            boxCount.text = "";
            touchBlocker.SetActive(true);

            if (gameEndTimer > gameEndTimerLimit)
            {
                nextLevelPanel.SetActive(true);
                GameStatusSoundEffect();
            }




            PlayerPrefs.SetString("L" + PlayerPrefs.GetInt("sceneNumber").ToString(), "Finished");

            if (PlayerPrefs.GetString("L" + (PlayerPrefs.GetInt("sceneNumber") + 1).ToString()) == "Locked")
            {
                PlayerPrefs.SetString("L" + (PlayerPrefs.GetInt("sceneNumber") + 1).ToString(), "Unlocked");
            }


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

    private void GameStatusSoundEffect()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {

                if (!GameEndSoundEffectCast)
                {
                    if (GameStatus == 1)
                    {
                        GetComponent<AudioSource>().volume = 1f;
                        GetComponent<AudioSource>().PlayOneShot(GameWinSoundEffect);
                        GameEndSoundEffectCast = true;
                    }
                    if (GameStatus == -1)
                    {
                        GetComponent<AudioSource>().volume = 1f;
                        GetComponent<AudioSource>().PlayOneShot(GameLoseSoundEffect);
                        GameEndSoundEffectCast = true;
                    }




                }

            }
        }
    }

    private void GameEndTimer()
    {
        if (GameStatus != 0)
        {
            gameEndTimer += Time.deltaTime;
        }

    }


    

}
