using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Game currentGame;
    public List<string> wordList;
    private string reponse;
    private bool win = false;
    public TMP_Text txt;
    private int i = 0;
    [SerializeField]
    IHMController iHMController;
    
    
    
    
    void Start()
    {
        StartNewGame();
    }

   public void StartNewGame()
    {
        currentGame = new Game(wordList);
    } 
    
    public void Validation(string letter){
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
    }
     void Verification()
    {
        if(win)
        {
           //AudioSource.PlayOneShot(SfxCorrect);

            if (txt.text == currentGame.wordToGuess)
            {
                Debug.Log("Vous avez gagné...");
            }
        }
        else
        {
            iHMController.Pendu.GetComponent<Image>().sprite = iHMController.sp[i];
            i++;
            //AudioBehaviour.PlayOneShot(SfxFailed);

            if(i==7)
            {
                Debug.Log("Vous avez perdu...");
            }
        }
    }
}
