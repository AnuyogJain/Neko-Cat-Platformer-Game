using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

public class APIScript : MonoBehaviour
{
    // Start is called before the first frame update
    string imageUrl = "https://thecatapi.com/api/images/get?format=src&type=png";
    void Start()
    {
        StartCoroutine(GetImage(imageUrl));
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetImage(string url) {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request) as Texture2D;
            GetComponent<Image>().sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), new Vector2(0, 0));
        }
    }
    
}
