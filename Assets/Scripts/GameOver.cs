using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public AudioSource audioPlayer;
    public GameObject cameraObject;
    public TextMeshProUGUI gameOverPanel; 
    public TextMeshProUGUI highScorePanel;
    public bool gameOver = false;
    public AudioSource milk;
    //-1->0.6
    //0.5->2.6
    //3.37->5.74
    //30.31->32.5
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Mathf.Clamp(transform.position.x, -100, cameraObject.transform.position.x + 2.1f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        if (gameOver == false && cameraObject.transform.position.x - gameObject.transform.position.x > 2.5)
        {
            gameObject.transform.position += new Vector3(0, -2, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            gameOver = true;
        }
        if (gameOver)
        {
            cameraObject.GetComponent<MoveCamera>().cameraSpeed = 0f;
            gameOverPanel.gameObject.SetActive(true);
            highScorePanel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameOver == false && collision.gameObject.tag == "Water")
        {
            gameObject.transform.position += new Vector3(0, -2, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //gameObject.GetComponent<Rigidbody2D>().mass = 0f;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            audioPlayer.Play();
            gameOver = true;
        }
        if (collision.tag == "Milk")
        {
            milk.Play();
        }
    }
    
}
