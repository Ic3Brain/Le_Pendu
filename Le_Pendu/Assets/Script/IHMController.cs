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
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine.U2D;

public class IHMController : MonoBehaviour
{   
    [SerializeField]
    public TMP_InputField inputField;
    
    [SerializeField]
    public Game currentGame;
    
    [SerializeField] 
    GameManager gameManager;
    
    public AudioClip SfxCorrect, SfxFailed;
    private AudioSource audiosource;
    
    public GameObject PanelEnd;
    public TMP_Text txt;
    [SerializeField]
    public Image spritePendu;
    public Sprite[] sp;
    
    
    
    
    
    
    
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    

    
    
    public void OnButtonClick()
    {
        Debug.Log("bouton cliqué" + inputField);
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
        //UpdateSprite();
    }

    public void UpdateSprite()
    {   
        for (int i = 0; i < currentGame.life; i++){
            
            spritePendu.sprite = sp[i];
        }
        
        //TO DO mettre propriété
    }
    
    public void HideGameOver()
    {
        PanelEnd.SetActive(false);
    }
}
