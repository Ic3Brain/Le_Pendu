using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Game currentGame;
    public List<string> wordList;
    
    
    [SerializeField]
    IHMController iHMController;
    public static GameManager INSTANCE;
    //public bool isInGame = true;
    
    
    
    void Awake()
    {
        INSTANCE = this;
    }
    
    
    void Start()
    {
        StartNewGame();
        
    }

    /*commence une nouvelle partie*/
   public void StartNewGame()
    {
        currentGame = new Game(wordList);
        iHMController.UpdateIhm();
        iHMController.HideGameOver();
        
    } 

    /*validation de la lettre jouée*/
    public void Validation(string letter)
    {   
        currentGame.IsMoveCorrect(letter);
        
        if(!currentGame.IsMoveCorrect(letter))
        OnBadMove();
        
        
        currentGame.AddPlayedLetter(letter);
        
        if(currentGame.ISWON)OnWIn(); 


        if(currentGame.ISGAMEOVER)OnGameOver(); 

        iHMController.UpdateIhm();
        
    }

    /*Gagné alors on affiche le text*/
    void OnWIn()
    {
        
        iHMController.PanelEnd.SetActive(true);
        iHMController.PanelEnd.GetComponentInChildren<TMP_Text>().text = "Vous avez gagné, le mot était bien " + currentGame.wordToGuess;
        
    }
    
    /*Perdu alors on affiche le text*/
    void OnGameOver()
    {
        iHMController.PanelEnd.SetActive(true);
        iHMController.PanelEnd.GetComponentInChildren<TMP_Text>().text = "Vous avez perdu, le mot était " + currentGame.wordToGuess;
    }

    /*Si faute alors life -- et on update la sprite*/
    void OnBadMove()
    {   
        currentGame.life --;
        iHMController.UpdateSprite();
    }
    /**/
    public void PlayedLetters()
    {
        iHMController.Nuage.GetComponentInChildren<TMP_Text>().text = "" + currentGame.playedLetters;
    }
}
