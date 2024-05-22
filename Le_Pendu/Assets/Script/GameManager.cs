using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
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
    [SerializeField]
    WordSite wordSite;
    public static GameManager INSTANCE;
    private AudioSource audioSource;
    [SerializeField] 
    AudioClip letterValidation;
    private AudioClip gameOver;
    private AudioClip gameWin;
    [SerializeField]
    AudioSource SFXaudioSource;
    
    
    
    
    void Awake()
    {
        INSTANCE = this;
        audioSource = GetComponent<AudioSource>();
    }
    
    
    void Start()
    {
        StartNewGame();
        
    }

    /*commence une nouvelle partie*/
   public void StartNewGame()
    {
        StartCoroutine(StartNewGameCorout());
    } 
    IEnumerator StartNewGameCorout()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            currentGame = new Game(wordList);
        }
        else
        {
            yield return wordSite.GetWord();
            currentGame = new Game(wordSite.answer.motChoisi);        
        }
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
        SFXaudioSource.clip = letterValidation;
        SFXaudioSource.Play();
    }

    /*Gagné alors on affiche le text*/
    void OnWIn()
    {
        
        iHMController.PanelEnd.SetActive(true);
        iHMController.PanelEnd.GetComponentInChildren<TMP_Text>().text = "Vous avez gagné, le mot était bien " + currentGame.wordToGuess;
        audioSource.PlayOneShot(gameWin);
        
    }
    
    /*Perdu alors on affiche le text*/
    void OnGameOver()
    {
        iHMController.PanelEnd.SetActive(true);
        iHMController.PanelEnd.GetComponentInChildren<TMP_Text>().text = "Vous avez perdu, le mot était " + currentGame.wordToGuess;
        currentGame.life = 7;
        iHMController.UpdateSprite(currentGame.life+1);
        audioSource.PlayOneShot(gameOver);

    }

    /*Si faute alors life -- et on update la sprite*/
    void OnBadMove()
    {   
        currentGame.life--;
        iHMController.UpdateSprite(currentGame.life+1);
        

    }
    /*montre la lettre jouée*/
    public void PlayedLetters()
    {
        string letter = "";
        foreach(var i in currentGame.playedLetters)
        {
            letter += i + ", ";
        }
        iHMController.letterPlayed.text = letter;
    }
}
