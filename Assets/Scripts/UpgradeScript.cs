using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeScript : MonoBehaviour
{
    public TMP_InputField eroInput;
    public TMP_InputField hpInput;
    public TMP_InputField dexInput;
    public TMP_InputField charisInput;
    public TMP_InputField agiliInput;
    public TMP_InputField manaInput;
    public TMP_InputField xpInput;

    public bool PlayerIsAtTheUpgrade;
    public GameObject dialog;
    public float ero;
    public float hp;
    public float dex;
    public float charis;
    public float agili;
    public float mana;
    public float xp;


    // Start is called before the first frame update
    void Start()
    {
        dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtTheUpgrade == true)
        {
            dialog.SetActive(true);
            PlayerMovement.speed = 0f;
            ero = PlayerController.strenght;
            hp = PlayerController.health;
            dex = PlayerController.dexterity;
            charis = PlayerController.charisma;
            agili = PlayerController.agility;
            mana = PlayerController.mana;
            xp  = PlayerController.xp;
            eroInput.text = ero.ToString();
            hpInput.text = hp.ToString();
            dexInput.text = dex.ToString();
            charisInput.text = charis.ToString();
            agiliInput.text = agili.ToString();
            manaInput.text = mana.ToString();
            xpInput.text = xp.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerIsAtTheUpgrade = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerIsAtTheUpgrade = false;
    }
}
