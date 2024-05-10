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
    
    
    void Start()
    {
        StartNewGame();
        currentGame.Validation("");
    }

   public void StartNewGame()
    {
        currentGame = new Game(wordList);
    } 
}
