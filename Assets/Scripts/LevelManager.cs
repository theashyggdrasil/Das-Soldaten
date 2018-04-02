using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public enum LevelState
{
    levelZero,
    levelOne,
    levelTwo,
    levelThree,
    levelFour,
    levelFive,
    levelSix,
    levelSeven,
    levelEight,
    levelNine,
    levelTen
}

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    public LevelState currentLevelState; // initializes the Level State to be zero, which is not ingame, change it based on level select, etc
    public bool levelTwoOn, levelThreeOn, levelFourOn, levelFiveOn, levelSixOn, levelSevenOn, levelEightOn, levelNineOn, levelTenOn;
    public float levelOneScore, levelTwoScore, levelThreeScore, levelFourScore, levelFiveScore, levelSixScore, levelSevenScore, levelEightScore, levelNineScore, levelTenScore;
    public float levelOneTime, levelTwoTime, levelThreeTime, levelFourTime, levelFiveTime, levelSixTime, levelSevenTime, levelEightTime, levelNineTime, levelTenTime;



    private void Awake()
    {
        

        if (instance == null)
        {    
            DontDestroyOnLoad(gameObject);
               instance = this;
            }
        else if (instance != null)
            {

                Destroy(gameObject);
            }
        Load();
    }
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        Scene scene = SceneManager.GetActiveScene();
        if (scene == SceneManager.GetSceneByName("MainMenu"))
        {
            LevelZero();
        }
        else if (scene == SceneManager.GetSceneByName("LevelOne"))
        {
            LevelOne();
        }
        else if (scene == SceneManager.GetSceneByName("LevelTwo"))
        {

            LevelTwo();
        }
        else if (scene == SceneManager.GetSceneByName("LevelThree"))
        {
            LevelThree();
        }
        else if (scene == SceneManager.GetSceneByName("LevelFour"))
        {
            LevelFour();
        }
        else if (scene == SceneManager.GetSceneByName("LevelFive"))
        {
            LevelFive();
        }
        else if (scene == SceneManager.GetSceneByName("LevelSix"))
        {
            LevelSix();
        }
        else if (scene == SceneManager.GetSceneByName("LevelSeven"))
        {
            LevelSeven();
        }
        else if (scene == SceneManager.GetSceneByName("LevelEight"))
        {
            LevelEight();
        }
        else if (scene == SceneManager.GetSceneByName("LevelNine"))
        {
            LevelNine();
        }
        else if (scene == SceneManager.GetSceneByName("LevelTen"))
        {
            LevelTen();
        }
    }
    

    void SetLevelState(LevelState newLevelState) //sets current level state, to load level
    {
        if(newLevelState == LevelState.levelZero)
        {
            currentLevelState = LevelState.levelZero;
            
        }
        else if(newLevelState == LevelState.levelOne)
        {
            currentLevelState = LevelState.levelOne;
            
            

        }
        else if (newLevelState == LevelState.levelTwo)
        {
            currentLevelState = LevelState.levelTwo;
            
            
        }
        else if (newLevelState == LevelState.levelThree)
        {
            currentLevelState = LevelState.levelThree;
            
            
        }
        else if (newLevelState == LevelState.levelFour)
        {
            currentLevelState = LevelState.levelFour;
            
           
        }
        else if (newLevelState == LevelState.levelFive)
        {
            currentLevelState = LevelState.levelFive;
            
          
        }
        else if (newLevelState == LevelState.levelSix)
        {
            currentLevelState = LevelState.levelSix;
            
           
        }
        else if (newLevelState == LevelState.levelSeven)
        {
            currentLevelState = LevelState.levelSeven;
            
            
        }
        else if (newLevelState == LevelState.levelEight)
        {
            currentLevelState = LevelState.levelEight;
            
            
        }
        else if (newLevelState == LevelState.levelNine)
        {
            currentLevelState = LevelState.levelNine;
            
            
        }
        else if (newLevelState == LevelState.levelTen)
        {
            currentLevelState = LevelState.levelTen;
            
            
        }
    }

    public void LevelZero()
    {
        SetLevelState(LevelState.levelZero);
    }

    public void LevelOne()
    {
        SetLevelState(LevelState.levelOne);
    }

    public void LevelTwo()
    {
        SetLevelState(LevelState.levelTwo);
    }

    public void LevelThree()
    {
        SetLevelState(LevelState.levelThree);
    }

    public void LevelFour()
    {
        SetLevelState(LevelState.levelFour);
    }

    public void LevelFive()
    {
        SetLevelState(LevelState.levelFive);
    }

    public void LevelSix()
    {
        SetLevelState(LevelState.levelSix);
    }

    public void LevelSeven()
    {
        SetLevelState(LevelState.levelSeven);
    }

    public void LevelEight()
    {
        SetLevelState(LevelState.levelEight);
    }

    public void LevelNine()
    {
        SetLevelState(LevelState.levelNine);
    }

    public void LevelTen()
    {
        SetLevelState(LevelState.levelTen);
    }

    public void LoadLevelOne()
    {
        
        SceneManager.LoadScene("LevelOne");
        GameManager.instance.InGame();
    }

    public void LoadLevelTwo()
    {
        if (levelTwoOn)
        {
            SceneManager.LoadScene("LevelTwo");
            GameManager.instance.InGame();
        }
    }

    public void LoadLevelThree()
    {
        if (levelThreeOn)
        {
            SceneManager.LoadScene("LevelThree");
            GameManager.instance.InGame();
        }
    }

    public void LoadLevelFour()
    {
        if (levelFourOn)
        { 
            SceneManager.LoadScene("LevelFour");
            GameManager.instance.InGame();
        }
    }

    public void LoadLevelFive()
    {
        if (levelFiveOn)
        {
            SceneManager.LoadScene("LevelFive");
            GameManager.instance.InGame();
        }
            
    }

    public void LoadLevelSix()
    {
        if (levelSixOn)
        {
            SceneManager.LoadScene("LevelSix");
            GameManager.instance.InGame();
        }
            
        
            
    }

    public void LoadLevelSeven()
    {
        if (levelSevenOn)
        {
            SceneManager.LoadScene("LevelSeven");
            GameManager.instance.InGame();
        }
            
        
            
    }

    public void LoadLevelEight()
    {
        if (levelEightOn)
        {
            SceneManager.LoadScene("LevelEight");
            GameManager.instance.InGame();
        }
            
        
        
    }

    public void LoadLevelNine()
    {
        if (levelNineOn)
        {
            SceneManager.LoadScene("LevelNine");
            GameManager.instance.InGame();
        }
            
        
        
    }

    public void LoadLevelTen()
    {
        if (levelTenOn)
        {
            SceneManager.LoadScene("LevelTen");
            GameManager.instance.InGame();
        }
            
        
    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        LevelData data = new LevelData();

        data.levelTwoOn = levelTwoOn;
        data.levelThreeOn = levelThreeOn;
        data.levelFourOn = levelFourOn ;
        data.levelFiveOn = levelFiveOn;
        data.levelSixOn = levelSixOn;
        data.levelSevenOn = levelSevenOn;
        data.levelEightOn = levelEightOn;
        data.levelNineOn = levelNineOn;
        data.levelTenOn = levelTenOn;

        data.levelOneScore = levelOneScore;
        data.levelTwoScore = levelTwoScore;
        data.levelThreeScore = levelThreeScore;
        data.levelFourScore = levelFourScore;
        data.levelFiveScore = levelFiveScore;
        data.levelSixScore = levelSixScore;
        data.levelSevenScore = levelSevenScore;
        data.levelEightScore = levelEightScore;
        data.levelNineScore = levelNineScore;
        data.levelTenScore = levelTenScore;

        data.levelOneTime = levelOneTime;
        data.levelTwoTime = levelTwoTime;
        data.levelThreeTime = levelThreeTime;
        data.levelFourTime = levelFourTime;
        data.levelFiveTime = levelFiveTime;
        data.levelSixTime = levelSixTime;
        data.levelSevenTime = levelSevenTime;
        data.levelEightTime = levelEightTime;
        data.levelNineTime = levelNineTime;
        data.levelTenTime = levelTenTime;

        bf.Serialize(file, data);
        file.Close();
        Debug.Log(file.Name);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
            LevelData data = (LevelData)bf.Deserialize(file); //pulls data out
            file.Close();

            levelTwoOn = data.levelTwoOn;
            levelThreeOn = data.levelThreeOn;
            levelFourOn = data.levelFourOn;
            levelFiveOn = data.levelFiveOn;
            levelSixOn = data.levelSixOn;
            levelSevenOn = data.levelSevenOn;
            levelEightOn = data.levelEightOn;
            levelNineOn = data.levelNineOn;
            levelTenOn = data.levelTenOn;

            data.levelOneScore = levelOneScore;
            data.levelTwoScore = levelTwoScore;
            data.levelThreeScore = levelThreeScore;
            data.levelFourScore = levelFourScore;
            data.levelFiveScore = levelFiveScore;
            data.levelSixScore = levelSixScore;
            data.levelSevenScore = levelSevenScore;
            data.levelEightScore = levelEightScore;
            data.levelNineScore = levelNineScore;
            data.levelTenScore = levelTenScore;

            data.levelOneTime = levelOneTime;
            data.levelTwoTime = levelTwoTime;
            data.levelThreeTime = levelThreeTime;
            data.levelFourTime = levelFourTime;
            data.levelFiveTime = levelFiveTime;
            data.levelSixTime = levelSixTime;
            data.levelSevenTime = levelSevenTime;
            data.levelEightTime = levelEightTime;
            data.levelNineTime = levelNineTime;
            data.levelTenTime = levelTenTime;
        }
    }

    [Serializable]
    class LevelData //serializes data, needs to be serializable
    {
        public bool levelTwoOn, levelThreeOn, levelFourOn, levelFiveOn, levelSixOn, levelSevenOn, levelEightOn, levelNineOn, levelTenOn;
        public float levelOneScore, levelTwoScore, levelThreeScore, levelFourScore, levelFiveScore, levelSixScore, levelSevenScore, levelEightScore, levelNineScore, levelTenScore;
        public float levelOneTime, levelTwoTime, levelThreeTime, levelFourTime, levelFiveTime, levelSixTime, levelSevenTime, levelEightTime, levelNineTime, levelTenTime;
    }
}


