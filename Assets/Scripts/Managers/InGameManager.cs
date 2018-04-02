using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour {
    public Text scoreLabel, healthLabel, timeLabel, zombieHealthLabel;
	
	
	// Update is called once per frame
	void Update () {
        scoreLabel.text = GameManager.instance.levelScore.ToString();
        healthLabel.text = PlayerManager.instance.characterHealth.ToString();
        timeLabel.text = GameManager.instance.playedTime.ToString("0");
        zombieHealthLabel.text = BossEnemyManager.instance.bossEnemyHealth.ToString("0");
	}
}
