using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Xml.Schema;

public class IHMController : MonoBehaviour
{   
    [SerializeField]
    TMP_InputField inputField;
    public Sprite[] sp;
    public GameObject Pendu;
    
    
    public void OnButtonClick()
    {
        Debug.Log("bouton cliqué" + inputField);

    }
}
