using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onclickdisable()
    {
        gameObject.SetActive(false);
        GameManager.Instance.isPlay = true;
    }
}
