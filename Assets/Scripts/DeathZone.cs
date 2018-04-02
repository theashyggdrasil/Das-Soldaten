using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            SoundManager.instance.heroDeathAudio.Play();
            GameManager.instance.GameOver();
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
