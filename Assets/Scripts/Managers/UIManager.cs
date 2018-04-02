using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    public Canvas MainMenu, LevelSelect, HighScore;

    private void Awake()
    {
        Screen.SetResolution(800, 600, false);
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        OnSceneLoad();
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (MainMenu.worldCamera == null)
        {
            MainMenu.worldCamera = Camera.main;
            LevelSelect.worldCamera = Camera.main;
            HighScore.worldCamera = Camera.main;
        } 
    }


    public void SetLevelSelectCanvasActive(bool isActive)
    {
        LevelSelect.gameObject.SetActive(isActive);
    }

    private void OnSceneLoad()
    {
        MainMenu = transform.Find("MainMenu").GetComponentInChildren<Canvas>();
        LevelSelect = transform.Find("LevelSelect").GetComponentInChildren<Canvas>();
        HighScore = transform.Find("HighScoreCanvas").GetComponentInChildren<Canvas>();

        MainMenu.renderMode = RenderMode.ScreenSpaceCamera;
        LevelSelect.renderMode = RenderMode.ScreenSpaceCamera;
        HighScore.renderMode = RenderMode.ScreenSpaceCamera;

        MainMenu.worldCamera = Camera.main;
        LevelSelect.worldCamera = Camera.main;
        HighScore.worldCamera = Camera.main;

        MainMenu.planeDistance = 100;
        LevelSelect.planeDistance = 100;
        HighScore.planeDistance = 100;

        LevelSelect.gameObject.SetActive(false);
        HighScore.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }


    public void SetMainMenuCanvasActive(bool isActive)
    {
        MainMenu.gameObject.SetActive(isActive);
    }

    public void SetHighScoreCanvasActive(bool isActive)
    {
        HighScore.gameObject.SetActive(isActive);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
