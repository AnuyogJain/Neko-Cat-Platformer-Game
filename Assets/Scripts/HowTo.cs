using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HowTo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SprintObject;
    bool isJoyStick;

    void Start()
    {
        isJoyStick = PlayerPrefs.GetInt("JoyStick") == 1 ? true : false;
        if (isJoyStick)
        {
            SprintObject.SetActive(false);
        }
        else
        {
            SprintObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void joystick()
    {
        isJoyStick = !isJoyStick;
        PlayerPrefs.SetInt("JoyStick", isJoyStick ? 1 : 0);
        if (isJoyStick)
        {
            SprintObject.SetActive(false);
        }
        else
        {
            SprintObject.SetActive(true);
        }
    }
    public void onClick() {
        SceneManager.LoadScene("Menu");
    }
}
