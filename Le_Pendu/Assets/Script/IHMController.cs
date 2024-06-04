using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


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
    private Transform cherryParent;
    
    [SerializeField]
    private List <CherryController> BoardCherry;
    public TMP_Text letterPlayed;
    public GameObject PanelSound;
    public GameObject PanelConnectionError;
    
    [SerializeField]
    Button validateButton;
    
    
    
    
    
    private void Awake()
    {
        ShowWord();
        GetAllCherries();
    }

    /*Renseigne toutes les cerises dans la list*/
    void GetAllCherries()
    {
        BoardCherry = new  List<CherryController>();
        
        foreach(Transform cherry in cherryParent)
        {
            BoardCherry.Add(cherry.GetComponent<CherryController>());
        }
    }
    
    /*créer le nombre de _*/
    void ShowWord()
    {
        foreach (char c in currentGame.wordToGuess)
        {
            txt.text += "_";
        }
    }
    
    /*Active ou désactive le boutton 'valider'*/
    public void EnableValidateButton(bool value)
    {
        validateButton.interactable = value;
    }
    
    /*Boutton validation des lettres*/
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

    /*Affiche le panel d'erreur de connection*/
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
        
           
        int index = Mathf.Clamp(life, 0, BoardCherry.Count-1);
        BoardCherry[index].FallFonction();
        
    }

    /*Replace les cerises au bon endroit*/
    public void ResetCherries()
    {
        foreach(var cherry in BoardCherry)
        {
            cherry.Reset();
        }
    }

    /*désactive le gameoverpanel*/
    public void HideGameOver()
    {
        PanelEnd.SetActive(false);
    }
}
