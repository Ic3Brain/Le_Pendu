using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Xml.Schema;
using Unity.VisualScripting.Antlr3.Runtime;
using System.Xml.XPath;

public class IHMController : MonoBehaviour
{   
    [SerializeField]
    public TMP_InputField inputField;
    public Sprite[] sp;
    public AudioClip SfxCorrect, SfxFailed;
    private AudioSource audiosource;
    [SerializeField] 
    GameManager gameManager;
    public GameObject PanelEnd;
    public TMP_Text txt;
    [SerializeField]
    public Image spritePendu;
    
    
    
    
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    

    
    
    public void OnButtonClick()
    {
        Debug.Log("bouton cliqué" + inputField);
        //gameManager.Validation(inputField.text);
        GameManager.INSTANCE.Validation(inputField.text);
    }

    private void UpdateGuessLetter()
    {
        string result = string.Empty;
        foreach(char c in gameManager.currentGame.wordToGuess)
        {
            if(gameManager.currentGame.LetterAlreadyPLayed(c.ToString()))result +=  c;
            else result += " _ ";
        }
        txt.text = result;

    }

    public void UpdateIhm()
    {
        UpdateGuessLetter();
    }

    public void UpdateSprite()
    {
         spritePendu.sprite = sp[0];
         //TO DO mettre propriété
    }
}
