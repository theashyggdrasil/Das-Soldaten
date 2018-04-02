using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager.instance.isSpeedBoostOn = true;
        PlayerManager.instance.isTimerOn = true;
        Destroy(gameObject);
    }
}
