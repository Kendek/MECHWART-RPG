using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BossDoorScript : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] TMP_Text dialogBossText;
    public string text;
    public string bossText;
    public static int volteKonyv;
    public GameObject DialogObj;
    public GameObject DialogObjBoss;
    bool isDone = false;
    bool isDoneBoss = false;

    public GameObject player;
    public bool PlayerIsAtThedoor;
    public string sceneName;

    public Vector2 playerPosition;
    public VectorValue playerStorage;
    private static int kulcsfolyosoBoss;
    public Image black;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        DialogObj.SetActive(false);
        DialogObjBoss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && PlayerIsAtThedoor == true)
        {
            changeScene();
        }
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtThedoor == true && kulcsfolyosoBoss == 3)
        {
            DialogObjBoss.SetActive(true);
            PlayerMovement.speed = 0f;
            StartCoroutine(TypeDialogBoss(bossText));
        }
        if (isDoneBoss == true && Input.GetKeyDown(KeyCode.E))
        {
            DialogObj.SetActive(false);
            DialogObjBoss.SetActive(false);
            changeScene();
        }
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtThedoor == true && kulcsfolyosoBoss !=3)
        {
            DialogObj.SetActive(true);
            PlayerMovement.speed = 0f;
            StartCoroutine(TypeDialog(text));
        }
        if (volteKonyv >= 2)
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

    public void changeScene()
    {
        StartCoroutine(Fading());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            kulcsfolyosoBoss = BossKulcs.kulcsBoss;
            Debug.Log(kulcsfolyosoBoss);
            PlayerIsAtThedoor = true;
            playerStorage.initialValue = playerPosition;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerIsAtThedoor = false;
    }
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(sceneName);
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
    public IEnumerator TypeDialogBoss(string dialogBoss)
    {
        dialogBossText.text = "";
        foreach (var letter in dialogBoss.ToCharArray())
        {
            dialogBossText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }
        isDoneBoss = true;
    }
}

