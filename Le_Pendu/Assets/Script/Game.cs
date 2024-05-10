using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
[System.Serializable]


public class Game 
{
    public List<string> playedLetters;
    public string wordToGuess;
    public int remainingTest;
    public TMP_Text txt;
    private string reponse;
    private bool win = false;
    
    
    

    //string motvide = string.empty;
    //motvide += "e";
    
    public Game(List<string> wordListToGuess)
    {
        playedLetters = new List<string>();
        remainingTest = 7;
        wordToGuess = GetRandomWord(wordListToGuess);

    }
    
    /*Choisi un mot dans la liste*/
    string GetRandomWord(List<string> wordToGuess)
    {
        int index = Random.Range(0, wordToGuess.Count);
        return wordToGuess[index];
    }
    
    public void Validation(string inputField){
        reponse = "";
        win = false;
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if(txt.text.Substring(i,1) == "_")
            {
                if(wordToGuess.Substring(i,1) == inputField)
                {
                    reponse += inputField;
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
    }
}
