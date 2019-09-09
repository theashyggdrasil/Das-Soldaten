using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource menuAudio, inGameAudio, bossBattleAudio, heroDeathAudio, hitAudio, enemyHitAudio, winAudio;
    public AudioSource[] soundManagerAudio;
    public static SoundManager instance;
    int muteCount = 1;


    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(this);
        IsMenuAudioOn(true);
        IsInGameAudioOn(false);
        IsBossBattleAudioOn(false);
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
        {

            Destroy(gameObject);
        }
        soundManagerAudio = gameObject.GetComponentsInChildren<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void IsMenuAudioOn(bool isOn)
    {
        if(isOn)
        {
            menuAudio.enabled = true;
        }
        else if(!isOn)
        {
            menuAudio.enabled = false;
        }
    }

    public void IsInGameAudioOn(bool isOn)
    {
        if (isOn)
        {
            inGameAudio.enabled = true;
        }
        else if (!isOn)
        {
            inGameAudio.enabled = false;
        }
    }

    public void IsBossBattleAudioOn(bool isOn)
    {
        if (isOn)
        {
            bossBattleAudio.enabled = true;
        }
        else if (!isOn)
        {
            bossBattleAudio.enabled = false;
        }
    }

    public void IsHeroDeathAudioOn(bool isOn)
    {
        if (isOn)
        {
            heroDeathAudio.enabled = true;
        }
        else if (!isOn)
        {
            heroDeathAudio.enabled = false;
        }
    }

    public void IsHitAudioOn(bool isOn)
    {
        if (isOn)
        {
            hitAudio.enabled = true;
        }
        else if (!isOn)
        {
            hitAudio.enabled = false;
        }
    }

    public void IsEnemyHitAudioOn(bool isOn)
    {
        if (isOn)
        {
            enemyHitAudio.enabled = true;
        }
        else if (!isOn)
        {
            enemyHitAudio.enabled = false;
        }
    }

    public void MuteEnabled()
    {

        if (muteCount == 1)
        {
            foreach (AudioSource c in soundManagerAudio)
            {
                c.volume = 0;
            }
            muteCount = 0;
        }
        else if(muteCount == 0)
        {
            foreach(AudioSource c in soundManagerAudio)
            {

                c.volume = 0.75f;
            }
            muteCount = 1;
        }
    }
}
