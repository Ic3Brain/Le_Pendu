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
using System.Linq;

public class IHMController : MonoBehaviour
{   
    [SerializeField]
    public TMP_InputField inputField;
    
    [SerializeField]
    public Game currentGame;
    
    [SerializeField] 
    GameManager gameManager;
    
    public GameObject PanelEnd;
    public TMP_Text txt;
    [SerializeField]
    public Image spritePendu;
    public Sprite[] sp;
    public TMP_Text letterPlayed;
    public GameObject PanelSound;
    
    private void Awake()
    {
        ShowWord();
    }
    
    /*créer le nombre de _*/
    void ShowWord()
    {
        foreach (char c in currentGame.wordToGuess)
        {
            txt.text += "_";
        }
    }
    
    /**/
    public void OnButtonClick()
    {
        GameManager.INSTANCE.Validation(inputField.text);
    }

    /*Active le PanelSound*/
    public void OnButtonClickSound()
    {
        PanelSound.SetActive(true);
    }

    /*Désactive le PanelSound*/
    public void OnbuttonClickSoundOff()
    {
        PanelSound.SetActive(false);
    }

    /*vérifie si la lettre est bonne ou pas*/
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

    /*met a jour l'ihm*/
    public void UpdateIhm()
    {
        UpdateGuessLetter();
        gameManager.PlayedLetters();
    }

    /*met a jour le sprite*/
    public void UpdateSprite(int life)
    {   
        if(life > 0)
        { 
            spritePendu.sprite = sp[life-1];
        }
    }
        
    /*désactive le gameoverpanel*/
    public void HideGameOver()
    {
        PanelEnd.SetActive(false);
    }
}
