using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SearchPanel : MonoBehaviour
{
    public TMP_InputField _inputField;
    
    void Start(){
        _inputField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    private void ValueChangeCheck()
    {
        Debug.Log("changed");
    }
}
