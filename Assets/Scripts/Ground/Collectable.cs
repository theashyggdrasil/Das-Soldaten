using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i = 0; i < 50; i++)
        {
            GameManager.instance.AddScore();
        }
        Destroy(gameObject);
        if (PlayerManager.instance.isDoubleJumpOn)
            PlayerManager.instance.isDoubleJumpOn = false;
        else if (PlayerManager.instance.isSpeedBoostOn)
            PlayerManager.instance.isSpeedBoostOn = false;
    }
}
