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
    
    
    void Awake()
    {
        INSTANCE = this;
    }
    
    
    void Start()
    {
        StartNewGame();
        
    }

   public void StartNewGame()
    {
        currentGame = new Game(wordList);
        iHMController.UpdateIhm();
    } 
    
    /*public void Validation(string letter){
        reponse = "";
        win = false;
        
        for (int i = 0; i < currentGame.wordToGuess.Length; i++)
        {
            if(txt.text.Substring(i, 1) == "_")
            {
                if(currentGame.wordToGuess.Substring(i, 1) == letter)
                {
                    reponse += letter;
                    win = true;
                }
                else
                {
                    reponse += "_";
                }
            }
            else 
            {
                reponse += txt.text.Substring(i, 1);
            }
        }
        txt.text = reponse;
        Verification();
    }*/
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
    void OnWIn()
    {
        
        iHMController.PanelEnd.SetActive(true);
        iHMController.PanelEnd.GetComponentInChildren<TMP_Text>().text = "Vous avez gagné, le mot était bien " + currentGame.wordToGuess;
        
    }
    
    void OnGameOver()
    {
        iHMController.PanelEnd.SetActive(true);
        iHMController.PanelEnd.GetComponentInChildren<TMP_Text>().text = "Vous avez perdu, le mot était " + currentGame.wordToGuess;
    }
    void OnBadMove()
    {   
        currentGame.life --;
        iHMController.UpdateSprite();
    }
}
