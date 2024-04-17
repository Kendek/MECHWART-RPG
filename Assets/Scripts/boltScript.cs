using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class boltScript : MonoBehaviour
{
    public TMP_InputField SmallHpPotionInput;
    public TMP_InputField BigHpPotionInput;
    public TMP_InputField SmallManaPotionInput;
    public TMP_InputField BigManaPotionInput;

    public bool PlayerIsAtTheShop;
    public GameObject dialog;
    public float SmallHpPotion;
    public float BigHpPotion;
    public float SmallManaPotion;
    public float BigManaPotion;



    // Start is called before the first frame update
    void Start()
    {
        dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtTheShop == true)
        {
            dialog.SetActive(true);
            PlayerMovement.speed = 0f;
            SmallHpPotion = PlayerController.SmallHpPotion;
            BigHpPotion = PlayerController.BigHpPotion;
            SmallManaPotion = PlayerController.SmallManaPotion;
            BigManaPotion = PlayerController.BigManaPotion;
            SmallHpPotionInput.text = SmallHpPotion.ToString();
            BigHpPotionInput.text = BigHpPotion.ToString();
            SmallManaPotionInput.text = SmallManaPotion.ToString();
            BigManaPotionInput.text = BigManaPotion.ToString();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerIsAtTheShop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerIsAtTheShop = false;
    }
}