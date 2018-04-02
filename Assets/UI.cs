using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    public static UI instance;
    public Canvas inGameCanvas, gameOverCanvas, pauseCanvas, nextLevelCanvas, backgroundCanvas;


    // Use this for initialization
    void Start () {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        //inGameCanvas = GameObject.Find("UI").GetComponentInChildren<Canvas>();
        //gameOverCanvas = GameObject.Find("gameOverCanvas").GetComponent<Canvas>();
        //pauseCanvas = GameObject.Find("pauseCanvas").GetComponent<Canvas>();
        //nextLevelCanvas = GameObject.Find("nextLevelCanvas").GetComponent<Canvas>();

        //inGameCanvas.enabled = false;
        //gameOverCanvas.enabled = false;
        //pauseCanvas.enabled = false;
        //nextLevelCanvas.enabled = false;
        //backgroundCanvas.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        inGameCanvas.worldCamera = Camera.main;
        gameOverCanvas.worldCamera = Camera.main;
        pauseCanvas.worldCamera = Camera.main;
        nextLevelCanvas.worldCamera = Camera.main;
        backgroundCanvas.worldCamera = Camera.main;
    }
}
