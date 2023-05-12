using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = -1;
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    int highScore;
    public bool isPlay = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void incrementScore()
    {
        
        score++;
        //scoreText.text = score.ToString();
       // highScore = Mathf.Max(highScore, score);
        scoreText.text = score.ToString();
        highScore = Mathf.Max(highScore, score);
        PlayerPrefs.SetInt("HighScore", highScore);
        highScoreText.text = "HighScore: " + highScore.ToString();
    }
    public void incrementScore(int num)
    {

        score+=num;
        //scoreText.text = score.ToString();
        // highScore = Mathf.Max(highScore, score);
        scoreText.text = score.ToString();
        highScore = Mathf.Max(highScore, score);
        PlayerPrefs.SetInt("HighScore", highScore);
        highScoreText.text = "HighScore: " + highScore.ToString();
    }
}
