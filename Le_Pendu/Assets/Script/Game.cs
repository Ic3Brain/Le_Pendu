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
}
