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

    [SerializeField]
    CherryController cherryController;
    
    public GameObject PanelEnd;
    public TMP_Text txt;
    
    
    
    public GameObject[] BoardCherry;
    public TMP_Text letterPlayed;
    public GameObject PanelSound;
    public GameObject PanelConnectionError;
    public GameObject CherryParent;
    
    
    
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

    public void OnButtonClickConnectionErrorOff()
    {
        PanelConnectionError.SetActive(false);
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
    public void UpdateCherry(int life)
    {   
        if(life > 0)
        { 
            CherryParent = BoardCherry[life-1];
            //cherryController.UnFreezeConstraintsCherry();
        }
    }

    /*désactive le gameoverpanel*/
    public void HideGameOver()
    {
        PanelEnd.SetActive(false);
    }
}
