using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Unity.VisualScripting;

public class WebRequest : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(GetRequest("http://127.0.0.1:5000/predict"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

        }
    }
}
