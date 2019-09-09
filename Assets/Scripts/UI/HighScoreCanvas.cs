using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreCanvas : MonoBehaviour {
    public Text levelOneScoreLabel, levelTwoScoreLabel, levelThreeScoreLabel, levelFourScoreLabel, levelFiveScoreLabel, levelSixScoreLabel, levelSevenScoreLabel,
        levelEightScoreLabel, levelNineScoreLabel, levelTenScoreLabel, levelOneTimeLabel, levelTwoTimeLabel, levelThreeTimeLabel, levelFourTimeLabel, levelFiveTimeLabel,
        levelSixTimeLabel, levelSevenTimeLabel, levelEightTimeLabel, levelNineTimeLabel, levelTenTimeLabel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        levelOneScoreLabel.text = LevelManager.instance.levelOneScore.ToString();
        levelTwoScoreLabel.text = LevelManager.instance.levelTwoScore.ToString();
        levelThreeScoreLabel.text = LevelManager.instance.levelThreeScore.ToString();
        levelFourScoreLabel.text = LevelManager.instance.levelFourScore.ToString();
        levelFiveScoreLabel.text = LevelManager.instance.levelFiveScore.ToString();
        levelSixScoreLabel.text = LevelManager.instance.levelSixScore.ToString();
        levelSevenScoreLabel.text = LevelManager.instance.levelSevenScore.ToString();
        levelEightScoreLabel.text = LevelManager.instance.levelEightScore.ToString();
        levelNineScoreLabel.text = LevelManager.instance.levelNineScore.ToString();
        levelTenScoreLabel.text = LevelManager.instance.levelTenScore.ToString();

        levelOneTimeLabel.text = LevelManager.instance.levelOneTime.ToString("0");
        levelTwoTimeLabel.text = LevelManager.instance.levelTwoTime.ToString("0");
        levelThreeTimeLabel.text = LevelManager.instance.levelThreeTime.ToString("0");
        levelFourTimeLabel.text = LevelManager.instance.levelFourTime.ToString("0");
        levelFiveTimeLabel.text = LevelManager.instance.levelFiveTime.ToString("0");
        levelSixTimeLabel.text = LevelManager.instance.levelSixTime.ToString("0");
        levelSevenTimeLabel.text = LevelManager.instance.levelSevenTime.ToString("0");
        levelEightTimeLabel.text = LevelManager.instance.levelEightTime.ToString("0");
        levelNineTimeLabel.text = LevelManager.instance.levelNineTime.ToString("0");
        levelTenTimeLabel.text = LevelManager.instance.levelTenTime.ToString("0");
    }
}
