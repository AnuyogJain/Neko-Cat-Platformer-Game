using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    bool isJoyStick = true;
    public Button joystickButton;
    // Start is called before the first frame update
    void Start()
    {
        isJoyStick = PlayerPrefs.GetInt("JoyStick") == 1 ? true: false;
        if (isJoyStick)
        {
            Color col = joystickButton.GetComponent<Image>().color;
            col.a = 1;
            joystickButton.GetComponent<Image>().color = col;
        }
        else
        {
            Color col = joystickButton.GetComponent<Image>().color;
            col.a = 0.5f;
            joystickButton.GetComponent<Image>().color = col;
        }
    }
    
    
    public void Play() {
        if (isJoyStick)
            SceneManager.LoadScene("Cat Joystick");
        else
            SceneManager.LoadScene("Cat");
    }

    public void Exit() {
        
        Application.Quit();
    }
    public void joystick() {
        isJoyStick = !isJoyStick;
        if (isJoyStick)
        {
            Color col = joystickButton.GetComponent<Image>().color;
            col.a = 1;
            joystickButton.GetComponent<Image>().color = col;
        }
        else {
            Color col = joystickButton.GetComponent<Image>().color;
            col.a = 0.5f;
            joystickButton.GetComponent<Image>().color = col;
        }
        PlayerPrefs.SetInt("JoyStick", isJoyStick ? 1 : 0);
    }
    public void howToClick() {
        SceneManager.LoadScene("How to");
    }
}
