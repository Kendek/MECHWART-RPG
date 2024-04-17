using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightDoors : MonoBehaviour
{
    public GameObject player;
    public bool PlayerIsAtThedoor;
    public string sceneName;
    public string nyertScene;

    public Vector2 playerPosition;
    public VectorValue playerStorage;

    public Image black;
    public Animator anim;

    public byte valami1 = 0;
    public byte valami4 = 0;


    // Start is called before the first frame update
    void Start()
    {
        valami1 = PlayerController.Fight1Win;
        valami4 = PlayerController.Fight4Win;

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtThedoor == true && valami1==1 && SceneManager.GetActiveScene().name == "1Emelet")
        {
            SceneManager.LoadScene(nyertScene);
        }
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtThedoor == true && valami4 == 1 && SceneManager.GetActiveScene().name == "Pince")
        {
            SceneManager.LoadScene(nyertScene);
        }
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtThedoor == true)
        {
            changeScene();
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
}