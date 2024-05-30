using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;

public class WordSite : MonoBehaviour
{
    [SerializeField]
    private string uri = "https://makeyourgame.fun/api/pendu/avoir-un-mot";
    
    public WordAnswer answer;
    
    /*start la coroutine*/
    public Coroutine GetWord()
    {
        return StartCoroutine(GetWordCorout(uri));
    }

    /*Permet d'aller chercher le mot via le site internet*/
     IEnumerator GetWordCorout(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // On envoie la requête et on attend la réponse
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                break;
                case UnityWebRequest.Result.Success:
                answer = JsonUtility.FromJson<WordAnswer>(webRequest.downloadHandler.text);
                break;
            }
        }
    }
}


public class WordAnswer
{
    public string status;
    public string motChoisi;
    public string regles;
    public int nombreDeMots;
    public int emplacementDuMotDansLeDictionnaire;
}
