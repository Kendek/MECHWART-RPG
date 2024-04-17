using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBox : MonoBehaviour
{

    [SerializeField] int letterPerSeconds;
    [SerializeField] TMP_Text dialogText;
    public string text;
    public static int volte;
    public GameObject DialogObj;
    public GameObject Tabla;
    bool isDone = false;

    void Start()
    {
        Tabla.SetActive(false);
        PlayerMovement.speed = 0f;
        StartCoroutine(TypeDialog(text));
        volte++;
        if (volte >= 2)
        {
            DialogObj.SetActive(false);
            Tabla.SetActive(true);
            PlayerMovement.speed = 5f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isDone ==true)
        {
            DialogObj.SetActive(false);
            PlayerMovement.speed = 5f;
            Tabla.SetActive(true);
        }        
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }
        isDone = true;
    }
}
