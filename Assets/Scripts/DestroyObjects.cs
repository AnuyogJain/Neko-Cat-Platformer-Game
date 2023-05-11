using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] cat = GameObject.FindGameObjectsWithTag("Cat");
        if (cat[0].transform.position.x - transform.position.x > 15)
            Destroy(gameObject);
    }

    

}
