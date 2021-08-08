using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputTextHandler : MonoBehaviour
{
    [SerializeField] TheAudience[] theAudiences;
    InputField input;
    void Start()
    {
        theAudiences = FindObjectsOfType<TheAudience>();
        input = GetComponent<InputField>();
    }
    public void OnInputValueChange()
    {
        var t = input.text;
        foreach(TheAudience audience in theAudiences)
        {
            //TODO: Good parser from text
        }
    }
}
