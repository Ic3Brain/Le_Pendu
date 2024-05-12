using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Xml.Schema;
using Unity.VisualScripting.Antlr3.Runtime;

public class IHMController : MonoBehaviour
{   
    [SerializeField]
    public TMP_InputField inputField;
    public Sprite[] sp;
    public GameObject Pendu;
    public AudioClip SfxCorrect, SfxFailed;
    private AudioSource audiosource;
    [SerializeField] 
    GameManager gameManager;
    
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    

    
    
    public void OnButtonClick()
    {
        Debug.Log("bouton cliqué" + inputField);
        gameManager.Validation(inputField.text);
    }
}
