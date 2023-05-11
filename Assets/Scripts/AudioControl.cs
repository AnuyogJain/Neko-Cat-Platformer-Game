using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    // Start is called before the first frame update
    bool isAudio;
    public Button audioButton;
    public GameObject maow;
    public GameObject splash;
    public GameObject BG;
    public GameObject Jump;

    void Start()
    {
        isAudio = PlayerPrefs.GetInt("isAudio") == 1 ? true : false;
        if (isAudio)
        {
            Color col = audioButton.GetComponent<Image>().color;
            col.a = 1;
            audioButton.GetComponent<Image>().color = col;
            maow.SetActive(true);
            splash.SetActive(true);
            BG.SetActive(true);
            Jump.SetActive(true);
        }
        else
        {
            Color col = audioButton.GetComponent<Image>().color;
            col.a = 0.5f;
            audioButton.GetComponent<Image>().color = col;
            maow.SetActive(false);
            splash.SetActive(false);
            BG.SetActive(false);
            Jump.SetActive(false);
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
            //maow.SetActive(true);
            splash.SetActive(true);
            BG.SetActive(true);
            Jump.SetActive(true);
        }
        else
        {
            Color col = audioButton.GetComponent<Image>().color;
            col.a = 0.5f;
            audioButton.GetComponent<Image>().color = col;
            maow.SetActive(false);
            splash.SetActive(false);
            BG.SetActive(false);
            Jump.SetActive(false);
        }
        PlayerPrefs.SetInt("isAudio", isAudio ? 1 : 0);
    }
}
