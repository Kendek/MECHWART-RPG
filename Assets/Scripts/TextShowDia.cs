using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextShowDia : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TMP_Text dialogText;
    public string text;
    public static int volte;
    public GameObject DialogObj;
    bool isDone = false;

    void Start()
    { 
        DialogObj.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            volte++;
            DialogObj.SetActive(true);
            PlayerMovement.speed = 0f;
            StartCoroutine(TypeDialog(text));
        }
    }
    void Update()
    {
        if(volte >= 2) 
        {
            DialogObj.SetActive(false);
            PlayerMovement.speed = 5f;
        }

        if (Input.GetKeyDown(KeyCode.E) && isDone == true)
        {
            DialogObj.SetActive(false);
            PlayerMovement.speed = 5f;
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
