using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishArea : MonoBehaviour {

    public Text newHighScore, newBestTime;

    private void Start()
    {
        newHighScore.enabled = false;
        newBestTime.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) // when reaches final zone, ends level, and allows player to go to next level or quit or main menu
    {
        
        if (collision.gameObject.tag == "Player") //initializes sequence of events to occur when player reaches finishzone
        {
            //sets the game manager to end of level sequence, also this makes time 0, so game clock does not increase
            GameManager.instance.NextLevel();
            Time.timeScale = 0.0f;
            SoundManager.instance.winAudio.Play();

            Scene scene = SceneManager.GetActiveScene(); //actions according to the current scene; this sets the score and time, and enables the next level to be started from the level select
            if (scene == SceneManager.GetSceneByName("LevelOne"))
            {
                if (GameManager.instance.playedTime < LevelManager.instance.levelOneTime || LevelManager.instance.levelOneTime == 0.0f)
                {
                    LevelManager.instance.levelOneTime = GameManager.instance.playedTime;
                    newBestTime.enabled = true;

                }

                if (GameManager.instance.levelScore > LevelManager.instance.levelOneScore || LevelManager.instance.levelOneScore == 0.0f)
                {
                    LevelManager.instance.levelOneScore = GameManager.instance.levelScore;
                    newHighScore.enabled = true;
                }

                LevelManager.instance.levelTwoOn = true;



            }
            else if (scene == SceneManager.GetSceneByName("LevelTwo"))
            {
                if (GameManager.instance.playedTime < LevelManager.instance.levelTwoTime || LevelManager.instance.levelTwoTime == 0.0f)
                {
                    LevelManager.instance.levelTwoTime = GameManager.instance.playedTime;
                    newBestTime.enabled = true;
                }

                if (GameManager.instance.levelScore > LevelManager.instance.levelOneScore || LevelManager.instance.levelTwoScore == 0.0f)
                {
                    LevelManager.instance.levelTwoScore = GameManager.instance.levelScore;
                    newHighScore.enabled = true;
                }

                LevelManager.instance.levelThreeOn = true;
                Debug.Log("LevelThreeOn");

            }
            else if (scene == SceneManager.GetSceneByName("LevelThree"))
            {
                if (GameManager.instance.playedTime < LevelManager.instance.levelThreeTime || LevelManager.instance.levelThreeTime == 0.0f)
                {
                    LevelManager.instance.levelThreeTime = GameManager.instance.playedTime;
                    newBestTime.enabled = true;
                }

                if (GameManager.instance.levelScore > LevelManager.instance.levelThreeScore || LevelManager.instance.levelThreeScore == 0.0f)
                {
                    LevelManager.instance.levelThreeScore = GameManager.instance.levelScore;
                    newHighScore.enabled = true;
                }

                LevelManager.instance.levelFourOn = true;

            }
            else if (scene == SceneManager.GetSceneByName("LevelFour"))
            {
                if (GameManager.instance.playedTime < LevelManager.instance.levelFourTime || LevelManager.instance.levelFourTime == 0.0f)
                { 
                    LevelManager.instance.levelFourTime = GameManager.instance.playedTime;
                    newBestTime.enabled = true;
                }

                if (GameManager.instance.levelScore > LevelManager.instance.levelFourScore || LevelManager.instance.levelFourScore == 0.0f)
                {
                    LevelManager.instance.levelFourScore = GameManager.instance.levelScore;
                    newHighScore.enabled = true;
                }

                LevelManager.instance.levelFiveOn = true;

            }
            else if (scene == SceneManager.GetSceneByName("LevelFive"))
            {
                if (GameManager.instance.playedTime < LevelManager.instance.levelFiveTime || LevelManager.instance.levelFiveTime == 0.0f)
                {
                    LevelManager.instance.levelFiveTime = GameManager.instance.playedTime;
                    newBestTime.enabled = true;
                }

                if (GameManager.instance.levelScore > LevelManager.instance.levelFiveScore || LevelManager.instance.levelFiveScore == 0.0f)
                {
                    LevelManager.instance.levelFiveScore = GameManager.instance.levelScore;
                    newHighScore.enabled = true;
                }

                LevelManager.instance.levelSixOn = true;

            }
            else if (scene == SceneManager.GetSceneByName("LevelSix"))
            {
                if (GameManager.instance.playedTime < LevelManager.instance.levelSixTime || LevelManager.instance.levelSixTime == 0.0f)
                {
                    LevelManager.instance.levelSixTime = GameManager.instance.playedTime;
                    newBestTime.enabled = true;
                }

                if (GameManager.instance.levelScore > LevelManager.instance.levelSixScore || LevelManager.instance.levelSixScore == 0.0f)
                {
                    LevelManager.instance.levelSixScore = GameManager.instance.levelScore;
                    newHighScore.enabled = true;
                }

                LevelManager.instance.levelSevenOn = true;

            }
            else if (scene == SceneManager.GetSceneByName("LevelSeven"))
            {
                if (GameManager.instance.playedTime < LevelManager.instance.levelSevenTime || LevelManager.instance.levelSevenTime == 0.0f)
                {
                    LevelManager.instance.levelSevenTime = GameManager.instance.playedTime;
                    newBestTime.enabled = true;
                }

                if (GameManager.instance.levelScore > LevelManager.instance.levelSevenScore || LevelManager.instance.levelSevenScore == 0.0f)
                {
                    LevelManager.instance.levelSevenScore = GameManager.instance.levelScore;
                    newHighScore.enabled = true;
                }

                LevelManager.instance.levelEightOn = true;

            }
            else if (scene == SceneManager.GetSceneByName("LevelEight"))
            {
                if (GameManager.instance.playedTime < LevelManager.instance.levelEightTime || LevelManager.instance.levelEightTime == 0.0f)
                {
                    LevelManager.instance.levelEightTime = GameManager.instance.playedTime;
                    newBestTime.enabled = true;
                }

                if (GameManager.instance.levelScore > LevelManager.instance.levelEightScore || LevelManager.instance.levelEightScore == 0.0f)
                {
                    LevelManager.instance.levelEightScore = GameManager.instance.levelScore;
                    newHighScore.enabled = true;
                }

                LevelManager.instance.levelNineOn = true;

            }
            else if (scene == SceneManager.GetSceneByName("LevelNine"))
            {
                if (GameManager.instance.playedTime < LevelManager.instance.levelNineTime || LevelManager.instance.levelNineTime == 0.0f)
                {
                    LevelManager.instance.levelOneTime = GameManager.instance.playedTime;
                    newBestTime.enabled = true;
                }

                if (GameManager.instance.levelScore > LevelManager.instance.levelNineScore || LevelManager.instance.levelNineScore == 0.0f)
                {
                    LevelManager.instance.levelNineScore = GameManager.instance.levelScore;
                    newHighScore.enabled = true;
                }

                LevelManager.instance.levelTenOn = true;

            }
            

            LevelManager.instance.Save();
        }
        
    }
}
