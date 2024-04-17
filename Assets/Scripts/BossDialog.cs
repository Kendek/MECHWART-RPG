using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BossDialog : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TMP_Text dialogText;
    public string text;
    public GameObject DialogObj;
    bool isDone = false;

    void Start()
    {
        PlayerMovement.speed = 0f;
        StartCoroutine(TypeDialog(text));
    }

    void Update()
    {
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