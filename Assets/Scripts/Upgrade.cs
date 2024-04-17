using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public float eroValt = 0;
    public float hpValt = 0;
    public float dexValt = 0;
    public float charisValt = 0;
    public float agiliValt = 0;
    public float manaValt = 0;
    public float xp = 0;

    public float ero = 0;
    public float hp = 0;
    public float dex = 0;
    public float chari = 0;
    public float aligi = 0;
    public float mana = 0;

    public bool vanxp;

    public TMP_InputField eroInput;
    public TMP_InputField hpInput;
    public TMP_InputField dexInput;
    public TMP_InputField charisInput;
    public TMP_InputField agiliInput;
    public TMP_InputField manaInput;
    public TMP_InputField xpInput;

    public GameObject dialog;
    public float maxxp = 0;

    // Start is called before the first frame update
    void Start()
    {
        xp= PlayerController.xp;
        maxxp = xp;
        xpInput.text = xp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Onclick()
    {
        dialog.SetActive(false);
        PlayerMovement.speed = 5f;
        ero = 0;
        hp = 0;
        dex = 0;
        chari = 0;
        aligi = 0;
        mana = 0;
    }
    public void RestartStat()
    {
        eroValt = 10;
        hpValt = 100;
        dexValt = 8;
        charisValt = 10;
        agiliValt = 10;
        manaValt = 100;
        xp = maxxp;

        ero = 0;
        hp = 0;
        dex = 0;
        chari = 0;
        aligi = 0;
        mana = 0;
        vanxp = true;
        PlayerController.strenght =eroValt;
        PlayerController.maxhealth= hpValt;
        PlayerController.health = PlayerController.maxhealth;
        PlayerController.mana = PlayerController.maxmana;
        PlayerController.dexterity= dexValt;
        PlayerController.charisma= charisValt;
        PlayerController.agility= agiliValt;
        PlayerController.maxmana= manaValt;
        //PlayerController.xp=xp;
        eroInput.text = eroValt.ToString();
        hpInput.text = hpValt.ToString();
        dexInput.text = dexValt.ToString();
        charisInput.text = charisValt.ToString();
        agiliInput.text = agiliValt.ToString();
        manaInput.text = manaValt.ToString();
        xpInput.text = maxxp.ToString();
    }

    public void Novel(int gombertek)
    {
        if (xp <= 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Elfogyott az Xp-d", "Ok");
            vanxp = false;
        }
        else 
        {
            vanxp = true;
        }
        if (gombertek==1 && xp>=25 && vanxp==true)
        {
            eroValt = PlayerController.strenght;
            eroValt+=10;
            PlayerController.strenght = eroValt;
            eroInput.text = eroValt.ToString();
            xp -= 25;
            ero++;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if(gombertek==2 && xp >= 25 && vanxp == true) 
        {
            hpValt = PlayerController.health;
            hpValt+=50;
            PlayerController.health = hpValt;
            hpInput.text = hpValt.ToString();
            xp -= 25;
            hp++;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if (gombertek == 3 && xp >= 25 && vanxp == true)
        {
            dexValt = PlayerController.dexterity;
            dexValt += 10;
            PlayerController.dexterity = dexValt;
            dexInput.text = dexValt.ToString();
            xp -= 25;
            dex++;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if (gombertek == 4 && xp >= 25 && vanxp == true)
        {
            charisValt = PlayerController.charisma;
            charisValt += 10;
            PlayerController.charisma = charisValt;
            charisInput.text = charisValt.ToString();
            xp -= 25;
            chari++;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if (gombertek == 5 && xp >= 25 && vanxp == true)
        {
            agiliValt = PlayerController.agility;
            agiliValt += 10;
            PlayerController.agility = agiliValt;
            agiliInput.text = agiliValt.ToString();
            xp -= 25;
            aligi++;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if (gombertek ==6 && xp >= 25 && vanxp == true)
        {
            manaValt = PlayerController.mana;
            manaValt += 50;
            PlayerController.mana = manaValt;
            manaInput.text = manaValt.ToString();
            xp -= 25;
            mana++;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }

    }
    public void Csokk(int gombertek)
    {
        if (gombertek == 1 && ero > 0)
        {
            eroValt = PlayerController.strenght;
            eroValt -= 10;
            PlayerController.strenght = eroValt;
            eroInput.text = eroValt.ToString();
            xp += 25;
            ero--;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if (gombertek == 1 && ero == 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Nem tudsz többet visszavonni", "Ok");
        }
        if (gombertek == 2 && hp > 0)
        {
            hpValt = PlayerController.health;
            hpValt -= 50;
            PlayerController.health = hpValt;
            hpInput.text = hpValt.ToString();
            xp += 25;
            hp--;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if (gombertek == 2 && hp == 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Nem tudsz többet visszavonni", "Ok");
        }
        if (gombertek == 3 && dex > 0)
        {
            dexValt = PlayerController.dexterity;
            dexValt -= 10;
            PlayerController.dexterity = dexValt;
            dexInput.text = dexValt.ToString();
            xp += 25;
            dex--;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if (gombertek == 3 && dex == 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Nem tudsz többet visszavonni", "Ok");
        }
        if (gombertek == 4 && chari > 0)
        {
            charisValt = PlayerController.charisma;
            charisValt -= 10;
            PlayerController.charisma = charisValt;
            charisInput.text = charisValt.ToString();
            xp += 25;
            chari--;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if (gombertek == 4 && chari == 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Nem tudsz többet visszavonni", "Ok");
        }
        if (gombertek == 5 && aligi > 0)
        {
            agiliValt = PlayerController.agility;
            agiliValt -= 10;
            PlayerController.agility = agiliValt;
            agiliInput.text = agiliValt.ToString();
            xp += 25;
            aligi--;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if (gombertek == 5 && aligi == 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Nem tudsz többet visszavonni", "Ok");
        }
        if (gombertek == 6 && mana > 0)
        {
            manaValt = PlayerController.mana;
            manaValt -= 50;
            PlayerController.mana = manaValt;
            manaInput.text = manaValt.ToString();
            xp += 25;
            mana--;
            xpInput.text = xp.ToString();
            PlayerController.xp = xp;
        }
        else if (gombertek == 6 && mana == 0)
        {
            EditorUtility.DisplayDialog("Figyelem", "Nem tudsz többet visszavonni", "Ok");
        }
    }
}
