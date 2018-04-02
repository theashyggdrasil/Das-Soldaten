using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    menu,
    inGame,
    gameOver,
    pause,
    nextLevel
}



public class GameManager : MonoBehaviour {

    public GameState currentGameState; // initializes the "currentGameState" which allow us to initially set the currentGameState to menu and have it change based on where
                                       //we are in the game
    public Canvas inGameCanvas, gameOverCanvas, pauseCanvas, nextLevelCanvas, backgroundCanvas;

    public static GameManager instance; // creates the singleton public variable of GameManager called instance

    public int levelScore;

    public float playedTime, startTime;

    void Awake()
    {
            inGameCanvas = GameObject.Find("InGameCanvas").GetComponent<Canvas>();
            gameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
            pauseCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
            nextLevelCanvas = GameObject.Find("NextLevelCanvas").GetComponent<Canvas>();
            backgroundCanvas = GameObject.Find("BackgroundCanvas").GetComponent<Canvas>();
        

        Scene scene = SceneManager.GetActiveScene();
        if (scene == SceneManager.GetSceneByName("MainMenu"))
        {
            MainMenu();
            SoundManager.instance.bossBattleAudio.Stop();
            

        }
        else if (scene == SceneManager.GetSceneByName("LevelOne") || scene == SceneManager.GetSceneByName("LevelTwo") || scene == SceneManager.GetSceneByName("LevelThree") || scene == SceneManager.GetSceneByName("LevelFour")
            || scene == SceneManager.GetSceneByName("LevelFive") || scene == SceneManager.GetSceneByName("LevelSix") || scene == SceneManager.GetSceneByName("LevelSeven") || scene == SceneManager.GetSceneByName("LevelEight")
             || scene == SceneManager.GetSceneByName("LevelNine") || scene == SceneManager.GetSceneByName("LevelTen"))
        {
            InGame();
            TimeReset();
            UIManager.instance.LevelSelect.enabled = false;
            UIManager.instance.MainMenu.enabled = false;
            SoundManager.instance.IsInGameAudioOn(true);
        }


    }

    // Use this for initialization
    void Start()
     {//using initialization to set the correct canvas set up using currentgamestate

        instance = this;
           
    }

    // Update is called once per frame
    void Update() {
        PlayTime();
        
    }

    public void InGame()
    {
        SetGameState(GameState.inGame); //change this to menu when doing actual game
        SoundManager.instance.IsMenuAudioOn(false);
        
        TimeReset();
    }
    
    public void GameOver()
    {
        SetGameState(GameState.gameOver); // sets game state to game over when running this method
    }

    private void MainMenu()
    {
        SetGameState(GameState.menu);
        SoundManager.instance.IsInGameAudioOn(false);

    }

    public void LoadMainMenu()
    {
        UIManager.instance.MainMenu.enabled = true;
        UIManager.instance.LevelSelect.enabled = true;
        SoundManager.instance.menuAudio.enabled = true;
        SoundManager.instance.menuAudio.Play();
        SceneManager.LoadScene("MainMenu");
        MainMenu();
    }

    public void NextLevel()
    {
        SetGameState(GameState.nextLevel);
        // add the stats and onswitches for end of level
    }

    public void QuitGame()
        {
            Application.Quit();
        }


    public void PauseGame()
    {
        SetGameState(GameState.pause); //sets the game state to pause
        Time.timeScale = 0.0f; // sets timescale to 0, so the gametime clock does not increase
    }


    public void AddScore() //Adds score, can be called anywhere
    {
        levelScore++;
        return;
    }

    public void PlayTime() // keep track of the time played
    {
        playedTime = Time.timeSinceLevelLoad;
    }

    public void StartTimeCollect()
    {
        startTime = Time.time;
    }

    public void TimeReset()
    {
        Time.timeScale = 1.0f;
    }

    public void LoadNextLevel()
    {
        
        Scene scene = SceneManager.GetActiveScene();
        if(scene == SceneManager.GetSceneByName("MainMenu"))
        {
            SceneManager.LoadScene("LevelOne");
        }
        else if (scene == SceneManager.GetSceneByName("LevelOne"))
        {
            SceneManager.LoadScene("LevelTwo");
            
        }
        else if (scene == SceneManager.GetSceneByName("LevelTwo"))
        {
            SceneManager.LoadScene("LevelThree");
        }
        else if (scene == SceneManager.GetSceneByName("LevelThree"))
        {
            SceneManager.LoadScene("LevelFour");
        }
        else if (scene == SceneManager.GetSceneByName("LevelFour"))
        {
            SceneManager.LoadScene("LevelFive");
        }
        else if (scene == SceneManager.GetSceneByName("LevelFive"))
        {
            SceneManager.LoadScene("LevelSix");
        }
        else if (scene == SceneManager.GetSceneByName("LevelSix"))
        {
            SceneManager.LoadScene("LevelSeven");
        }
        else if (scene == SceneManager.GetSceneByName("LevelSeven"))
        {
            SceneManager.LoadScene("LevelEight");
        }
        else if (scene == SceneManager.GetSceneByName("LevelEight"))
        {
            SceneManager.LoadScene("LevelNine");
        }
        else if (scene == SceneManager.GetSceneByName("LevelNine"))
        {
            SceneManager.LoadScene("LevelTen");
        }
        else if (scene == SceneManager.GetSceneByName("LevelTen"))
        {
            
        }
    }


void SetGameState (GameState newGameState)
    {
        //maintain what canvas is currently on or off
        if(newGameState == GameState.menu)
        {
            currentGameState = GameState.menu;
            gameOverCanvas.enabled = false;
            inGameCanvas.enabled = false;
            pauseCanvas.enabled = false;
            nextLevelCanvas.enabled = false;
            backgroundCanvas.enabled = false;

        }

        else if(newGameState == GameState.gameOver)
        {
            currentGameState = GameState.gameOver;
            gameOverCanvas.enabled = true;
            inGameCanvas.enabled = false;
            pauseCanvas.enabled = false;
            nextLevelCanvas.enabled = false;
            backgroundCanvas.enabled = true;
            

        }
        else if(newGameState == GameState.inGame)
        {
            currentGameState = GameState.inGame;
            gameOverCanvas.enabled = false;
            inGameCanvas.enabled = true;
            pauseCanvas.enabled = false;
            nextLevelCanvas.enabled = false;
            backgroundCanvas.enabled = true;
        }

        else if (newGameState == GameState.pause)
        {
            currentGameState = GameState.pause;
            gameOverCanvas.enabled = false;
            inGameCanvas.enabled = false;
            pauseCanvas.enabled = true;
            nextLevelCanvas.enabled = false;
            backgroundCanvas.enabled = true;

        }
        
        else if (newGameState == GameState.nextLevel)
        {
            currentGameState = GameState.nextLevel;
            gameOverCanvas.enabled = false;
            inGameCanvas.enabled = false;
            pauseCanvas.enabled = false;
            nextLevelCanvas.enabled = true;
            backgroundCanvas.enabled = true;

        }
    }


    

    
}
