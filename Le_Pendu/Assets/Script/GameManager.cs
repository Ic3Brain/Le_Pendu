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

    [SerializeField] 
    AudioClip letterValidation;
    
    [SerializeField] 
    AudioClip gameOver;
    
    [SerializeField] 
    AudioClip gameWin;
    
    [SerializeField]
    AudioSource SFXAudioSource;
    
    
    
    
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
        StartCoroutine(StartNewGameCorout());
        iHMController.ResetCherries();
        iHMController.EnableValidateButton(true);
    } 
    
    /*Cherche si l'utilisateur a de la connexion, si non alors affiche le PannelError. Si oui alors créer un mot via le site*/
    IEnumerator StartNewGameCorout()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {   
            iHMController.PanelConnectionError.SetActive(true);
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
        
        if(currentGame.ISWON)
        {   
            OnWIn();
            return;
        }
   

        if(currentGame.ISGAMEOVER)
        {
            StartCoroutine(OnGameOver());
            return;
        }
        
        iHMController.UpdateIhm();
        SFXAudioSource.clip = letterValidation;
        SFXAudioSource.Play();
    }

    /*Gagné alors on affiche le text*/
    void OnWIn()
    {
        iHMController.EnableValidateButton(false);
        iHMController.PanelEnd.SetActive(true);
        iHMController.PanelEnd.GetComponentInChildren<TMP_Text>().text = "Vous avez gagné, le mot était bien " + currentGame.wordToGuess;
        
        SFXAudioSource.clip = gameWin;
        SFXAudioSource.Play();
    }
    
    /*Perdu alors on affiche le text*/
    IEnumerator OnGameOver()
    {   
        iHMController.EnableValidateButton(false);
        yield return new WaitForSeconds(2);
        iHMController.PanelEnd.SetActive(true);
        iHMController.PanelEnd.GetComponentInChildren<TMP_Text>().text = "Vous avez perdu, le mot était " + currentGame.wordToGuess;
        currentGame.life = 7;
        iHMController.UpdateCherry(currentGame.life+1);
        
        SFXAudioSource.clip = gameOver;
        SFXAudioSource.Play();
        

    }

    /*Si faute alors life -- et on update la sprite*/
    void OnBadMove()
    {   
        currentGame.life--;
        iHMController.UpdateCherry(currentGame.life);
        

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
