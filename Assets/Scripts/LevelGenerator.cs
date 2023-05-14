using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform level;
    public Transform ground;
    public Vector3 spawnEndPos;
    public GameObject player;
    float distanceFromPlayer = 20;
    public GameObject[] milk;
    public GameObject[] bowls;
    float bg = 0; 
    private void Awake()
    {
        

        spawnGround(new Vector3(0f, 0f));
        /*spawnGround(spawnEndPos + new Vector3(1f, 0f));
        spawnGround(spawnEndPos + new Vector3(1f, 0f));
        spawnGround(spawnEndPos + new Vector3(1f, 0f));
        spawnGround(spawnEndPos + new Vector3(1f, 0f));*/
    }
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, spawnEndPos) < distanceFromPlayer) {
            float xRandom = UnityEngine.Random.Range(0.4f, 0.7f);
            //-0.2, 0.7
            
            float yRandom = UnityEngine.Random.Range(-0.2f, 0.7f);
            while (spawnEndPos.y - yRandom < -0.5f) {
                yRandom = UnityEngine.Random.Range(-0.2f, 0.7f);
            }

            spawnGround(spawnEndPos + new Vector3(xRandom, 0 + yRandom));
            
        }
        if (Vector3.Distance(player.transform.position, new Vector3(bg, 0, 0)) < distanceFromPlayer) {
            spawnLevel(new Vector3(bg, 0f));
            bg += 4;
        }
    }
    //0.5783 , -0.174 - 0.578
    //0.2, 0.4
    private void spawnLevel(Vector3 spawnPosition)
    {
        Transform temp = Instantiate(level, spawnPosition, Quaternion.identity);
        if (GameManager.Instance)
        {
            int tempNum = GameManager.Instance.score / 100;
            if (GameManager.Instance.score - (tempNum * 100) > 33)
            {
                temp.GetChild(0).GetComponent<Renderer>().material.color = new Color(193 / 255f, 243 / 255f, 185 / 255f);
            }
            if (GameManager.Instance.score - (tempNum * 100) > 66)
            {
                temp.GetChild(0).GetComponent<Renderer>().material.color = new Color(255 / 255f, 186 / 255f, 132 / 255f);
            }
            /*int tempNum = GameManager.Instance.score;
            temp.GetChild(0).GetComponent<Renderer>().material.color = new Color(255 / 255f, (255 - tempNum * 2) / 255f, (255 - tempNum * 2) / 255f);*/
        }
        //temp.GetChild(0).GetComponent<Renderer>().material.color = new Color(255 / 255f, 197 / 255f, 151 / 255f);
        //temp.GetChild(0).GetComponent<Renderer>().material.color = new Color(203 / 255f, 105 / 255f, 82 / 255f);
    }
    private void spawnGround(Vector3 spawnPosition)
    {
        //Transform temp1 = Instantiate(ground, spawnPosition + new Vector3(0,2,0), Quaternion.identity);
        float sizeRandom = UnityEngine.Random.Range(0.1f, 0.3f);
        if (GameManager.Instance) {
            if (GameManager.Instance.score > 50)
            {
                sizeRandom = UnityEngine.Random.Range(0.1f, 0.25f);
            }
            if (GameManager.Instance.score > 70)
            {
                sizeRandom = UnityEngine.Random.Range(0.1f, 0.2f);
            }
            if (GameManager.Instance.score > 100)
            {
                sizeRandom = UnityEngine.Random.Range(0.1f, 0.15f);
            }

        }
        
        //temp.GetChild(0).transform.localScale = new Vector3(sizeRandom, sizeRandom, 0);
        Transform temp = Instantiate(ground, spawnPosition, Quaternion.identity);
        temp.GetChild(0).transform.localScale = new Vector3(sizeRandom, sizeRandom, 0);
        int isMilk = UnityEngine.Random.Range(0, 4);
        if (isMilk >= 1) {
            int whichMilkProb = UnityEngine.Random.Range(0, 1800);
            if (whichMilkProb < 1000)
                Instantiate(milk[0], spawnPosition + new Vector3(0, 0.2f, 0), Quaternion.identity);
            else if (whichMilkProb < 1500)
                Instantiate(milk[1], spawnPosition + new Vector3(0, 0.2f, 0), Quaternion.identity);
            else if (whichMilkProb < 1700)
                Instantiate(milk[2], spawnPosition + new Vector3(0, 0.2f, 0), Quaternion.identity);
            else
                Instantiate(milk[3], spawnPosition + new Vector3(0, 0.2f, 0), Quaternion.identity);
        }
        //GameObject temp2 = Instantiate(bowls[UnityEngine.Random.Range(0, 2)], temp.position + new Vector3(1.08f, -(0.3f-sizeRandom), 0), Quaternion.identity);
        
        spawnEndPos = temp.GetChild(0).GetChild(0).position;
        spawnEndPos.y = 0;
    }
}
