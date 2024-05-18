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
    
    public AudioClip SfxCorrect, SfxFailed;
    private AudioSource audiosource;
    
    public GameObject PanelEnd;
    public TMP_Text txt;
    [SerializeField]
    public Image spritePendu;
    public Sprite[] sp;
    public GameObject Nuage;
    
    
    
    
    
    
    
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        ShowWord();
        
    }
    
    /*créer le nombre de _*/
    void ShowWord()
    {
        foreach (char c in currentGame.wordToGuess)
        {
            if(c.ToString() == "-")
            {
                txt.text += "-";
            }
            else if(c.ToString() == "'")
            {
                txt.text += "'";
            }
            else
            {
                txt.text += "_";
            }
        }
    }
    
    /**/
    public void OnButtonClick()
    {
        Debug.Log("bouton cliqué" + inputField);
        GameManager.INSTANCE.Validation(inputField.text);
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
        UpdateSprite();
    }

    /*met a jour le sprite*/
    public void UpdateSprite()
    
    {   
        spritePendu.sprite = sp[0];
    }
        
        //TO DO mettre propriété
    
    /*désactive le gameoverpanel*/
    public void HideGameOver()
    {
        PanelEnd.SetActive(false);
    }
}
