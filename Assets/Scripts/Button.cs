using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickRetry() {
        SceneManager.LoadScene("Cat");
    }
    public void onClickRetryJoy()
    {
        SceneManager.LoadScene("Cat Joystick");
    }
    public void onClickHome()
    {
        SceneManager.LoadScene("Menu");
    }
}
