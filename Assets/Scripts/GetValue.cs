using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetValue : MonoBehaviour
{
    [SerializeField] TMP_InputField username;

    public void SaveUserName()
    { 
        string dataToKeep = username.text;
        StaticData.valueToKeep = dataToKeep;
    }
}
