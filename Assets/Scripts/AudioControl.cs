using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    // Start is called before the first frame update
    bool isAudio;
    bool isMusic;
    public Button audioButton;
    public GameObject[] audios;
    public Button musicButton;
    public GameObject bgAudio;
    void Start()
    {
        isAudio = PlayerPrefs.GetInt("isAudio") == 1 ? true : false;
        isMusic = PlayerPrefs.GetInt("isMusic") == 1 ? true : false;
        print(isMusic);
        print(isAudio);
        if (isAudio)
        {
            Color col = audioButton.GetComponent<Image>().color;
            col.a = 1;
            audioButton.GetComponent<Image>().color = col;
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].SetActive(true);
            }
            print(audioButton.GetComponent<Image>().color.a);
        }
        else
        {
            Color col = audioButton.GetComponent<Image>().color;
            col.a = 0.5f;
            audioButton.GetComponent<Image>().color = col;
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].SetActive(false);
            }
        }
        if (isMusic)
        {
            Color col = musicButton.GetComponent<Image>().color;
            col.a = 1;
            musicButton.GetComponent<Image>().color = col;
            bgAudio.SetActive(true);
        }
        else
        {
            Color col = musicButton.GetComponent<Image>().color;
            col.a = 0.5f;
            musicButton.GetComponent<Image>().color = col;
            bgAudio.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void audioClick ()
    {
        isAudio = !isAudio;
        if (isAudio)
        {
            Color col = audioButton.GetComponent<Image>().color;
            col.a = 1;
            audioButton.GetComponent<Image>().color = col;
            for (int i = 1; i < audios.Length; i++)
            {
                audios[i].SetActive(isAudio);
            }
        }
        else
        {
            Color col = audioButton.GetComponent<Image>().color;
            col.a = 0.5f;
            audioButton.GetComponent<Image>().color = col;
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].SetActive(isAudio);
            }
        }
        PlayerPrefs.SetInt("isAudio", isAudio ? 1 : 0);
    }
    public void musicClick()
    {
        isMusic = !isMusic;
        if (isMusic)
        {
            Color col = musicButton.GetComponent<Image>().color;
            col.a = 1;
            musicButton.GetComponent<Image>().color = col;
        }
        else
        {
            Color col = musicButton.GetComponent<Image>().color;
            col.a = 0.5f;
            musicButton.GetComponent<Image>().color = col;
        }
        bgAudio.SetActive(isMusic);
        PlayerPrefs.SetInt("isMusic", isMusic ? 1 : 0);
    }
}
