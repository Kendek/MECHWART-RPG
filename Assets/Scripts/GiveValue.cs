using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GiveValue : MonoBehaviour
{
    [SerializeField] TMP_Text myText;
    [SerializeField] TMP_InputField CoinText;

    public void Start()
    {
        string newName = StaticData.valueToKeep;
        string newCoin = PlayerController.coin.ToString();
        myText.text = newName;
        CoinText.text = newCoin;
        Debug.Log(myText);
    }
}
