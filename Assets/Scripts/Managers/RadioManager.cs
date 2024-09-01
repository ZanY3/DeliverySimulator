using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RadioManager : MonoBehaviour
{
    public AudioClip[] music;
    public string[] musicNames;
    public TMP_Text musicNameText;

    private bool isOn = false;
    private int musicIndex;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(isOn && !source.isPlaying)
        {
            RadioSkipMusic();
        }

        if (!isOn && Input.GetKeyDown(KeyCode.R))
        {
            RadioOn();
        }
        else if (isOn && Input.GetKeyDown(KeyCode.R))
        {
            RadioOff();
        }
        else if (isOn && Input.GetKeyDown(KeyCode.Tab))
        {
            RadioSkipMusic();
        }
    }

    public void RadioOn()
    {
        isOn = true;
        musicIndex = 0;
        musicNameText.text = musicNames[musicIndex];

        source.clip = music[musicIndex];
        source.Play();
    }

    public void RadioOff()
    {
        isOn = false;
        musicIndex = 0;
        musicNameText.text = "Радио выключено, R чтобы вкл/выкл";

        source.clip = null;
        source.Stop();
    }

    public void RadioSkipMusic()
    {
        if (isOn)
        {
            if(musicIndex >= music.Length)
            {
                musicIndex = 0;
            }
            else
                musicIndex++;

            musicNameText.text = musicNames[musicIndex];
            source.clip = music[musicIndex];
            source.Play();
        }
    }
}
