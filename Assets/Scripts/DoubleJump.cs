using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager.instance.isDoubleJumpOn = true;
        PlayerManager.instance.isTimerOn = true;
        Destroy(gameObject);
    }
    
}
