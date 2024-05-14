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
    int remainingTest;
    public int life
    {
        get
        {    
            return remainingTest;
        }
        set
        {
            remainingTest = value;
            Debug.Log("valeur modifiée");
        }
    }

    public bool ISWON
    {
        get
        {
            foreach(char c in wordToGuess)
            {
                if(!playedLetters.Contains(c.ToString()))
                return false;
            }
            return true;
        }
    }

    public bool ISGAMEOVER
    {
        get
        {
            return life <= 0;
        }
    }

     
    
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

    private bool WordContainsLetter(string letter)
    {
        return wordToGuess.Contains(letter);
    }

    public bool LetterAlreadyPLayed(string letter)
    {
        return playedLetters.Contains(letter);
    }

    public bool IsMoveCorrect(string letter)
    {
        if (!WordContainsLetter(letter))
        return false;

        if(LetterAlreadyPLayed(letter))
        return false;

        return true;
    }

    public void AddPlayedLetter(string letter)
    {   
        if(playedLetters.Contains(letter))
        return;
        playedLetters.Add(letter);
    }
}
