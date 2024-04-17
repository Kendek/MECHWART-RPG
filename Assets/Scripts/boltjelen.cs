using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class boltjelen : MonoBehaviour
{
    public TMP_InputField SmallHpPotionInput;
    public TMP_InputField BigHpPotionInput;
    public TMP_InputField SmallManaPotionInput;
    public TMP_InputField BigManaPotionInput;
    public TMP_InputField coinInput;

    public float khp;
    public float nhp;
    public float kman;
    public float nman;

    public GameObject bufe;
    public float SmallHpPotions;
    public float BigHpPotions;
    public float SmallManaPotions;
    public float BigManaPotions;
    public float coinGets;

    public bool vancoin;
    // Start is called before the first frame update
    void Start()
    {
        coinGets = PlayerController.coin;
        coinInput.text = coinGets.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick()
    {
        bufe.SetActive(false);
        PlayerMovement.speed = 5f;
        khp = 0;
        nhp = 0;
        kman = 0;
        nman = 0;
    }

    public void Novel(int gombertek)
    {
        if (coinGets <= 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Elfogyott a Coinod", "Ok");
            vancoin = false;
        }
        else
        {
            vancoin = true;
        }
        if (gombertek == 1 && coinGets >= 25 && vancoin == true)
        {
            SmallHpPotions = PlayerController.SmallHpPotion;
            SmallHpPotions += 1;
            PlayerController.SmallHpPotion = SmallHpPotions;
            SmallHpPotionInput.text = SmallHpPotions.ToString();
            coinGets -= 25;
            khp++;
            coinInput.text = coinGets.ToString();
            PlayerController.coin = coinGets;
        }
        else if (gombertek == 2 && coinGets >= 25 && vancoin == true)
        {
            BigHpPotions = PlayerController.BigHpPotion;
            BigHpPotions += 1;
            PlayerController.BigHpPotion = BigHpPotions;
            BigHpPotionInput.text = BigHpPotions.ToString();
            coinGets -= 25;
            nhp++;
            coinInput.text = coinGets.ToString();
            PlayerController.coin = coinGets;
        }
        else if (gombertek == 3 && coinGets >= 25 && vancoin == true)
        {
            SmallManaPotions = PlayerController.SmallManaPotion;
            SmallManaPotions += 1;
            PlayerController.SmallManaPotion = SmallManaPotions;
            SmallManaPotionInput.text = SmallManaPotions.ToString();
            coinGets -= 25;
            kman++;
            coinInput.text = coinGets.ToString();
            PlayerController.coin = coinGets;
        }
        else if (gombertek == 4 && coinGets >= 25 && vancoin == true)
        {
            BigManaPotions = PlayerController.BigManaPotion;
            BigManaPotions += 1;
            PlayerController.BigManaPotion = BigManaPotions;
            BigManaPotionInput.text = BigManaPotions.ToString();
            coinGets -= 25;
            nman++;
            coinInput.text = coinGets.ToString();
            PlayerController.coin = coinGets;
        }
    }
    public void Csokk(int gombertek)
    {
        if (gombertek == 1 && khp > 0)
        {
            SmallHpPotions = PlayerController.SmallHpPotion;
            SmallHpPotions -= 1;
            PlayerController.SmallHpPotion = SmallHpPotions;
            SmallHpPotionInput.text = SmallHpPotions.ToString();
            coinGets += 25;
            khp--;
            coinInput.text = coinGets.ToString();
            PlayerController.coin = coinGets;
        }
        else if (gombertek == 1 && khp == 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Nem tudsz t�bbet visszavonni", "Ok");
        }
        if (gombertek == 2 && nhp > 0)
        {
            BigHpPotions = PlayerController.BigHpPotion;
            BigHpPotions -= 1;
            PlayerController.BigHpPotion = BigHpPotions;
            BigHpPotionInput.text = BigHpPotions.ToString();
            coinGets += 25;
            nhp--;
            coinInput.text = coinGets.ToString();
            PlayerController.coin = coinGets;
        }
        else if (gombertek == 2 && nhp == 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Nem tudsz t�bbet visszavonni", "Ok");
        }
        if (gombertek == 3 && kman > 0)
        {
            SmallManaPotions = PlayerController.SmallManaPotion;
            SmallManaPotions -= 1;
            PlayerController.SmallManaPotion = SmallManaPotions;
            SmallManaPotionInput.text = SmallManaPotions.ToString();
            coinGets += 25;
            kman--;
            coinInput.text = coinGets.ToString();
            PlayerController.coin = coinGets;
        }
        else if (gombertek == 3 && kman == 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Nem tudsz t�bbet visszavonni", "Ok");
        }
        if (gombertek == 4 && nman > 0)
        {
            BigManaPotions = PlayerController.BigManaPotion;
            BigManaPotions -= 1;
            PlayerController.BigHpPotion = BigHpPotions;
            BigHpPotionInput.text = BigHpPotions.ToString();
            coinGets += 25;
            nman--;
            coinInput.text = coinGets.ToString();
            PlayerController.coin = coinGets;
        }
        else if (gombertek == 4 && nman == 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Nem tudsz t�bbet visszavonni", "Ok");
        }
    }
}