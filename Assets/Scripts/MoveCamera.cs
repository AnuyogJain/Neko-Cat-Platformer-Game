using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float cameraSpeed;
    bool moveCamera = false;
    bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Wait");
        StartCoroutine("IncreaseSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlay) { 
            if (moveCamera)
                transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        }
        
    }

    IEnumerator IncreaseSpeed()
    {
        while (cameraSpeed < 1.8)
        {
            yield return new WaitForSeconds(2f);
            cameraSpeed += 0.01f;
        }
        
    }
    IEnumerator Wait()
    {
        while (GameManager.Instance.isPlay == false) {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        if (isPause == false)
            moveCamera = true;
    }

    public void onClickItchDown() {
        
        isPause = !isPause;

        if (isPause)
        {
            moveCamera = false;
        }

        else
        {
            moveCamera = true;
        }
    }
    public void onClickItchUp()
    {
        moveCamera  =true;
    }
}
