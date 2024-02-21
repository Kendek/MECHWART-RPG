using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LockedDoor2 : MonoBehaviour
{
    public GameObject player;
    public bool PlayerIsAtThedoor;
    public string sceneName;

    public Vector2 playerPosition;
    public VectorValue playerStorage;
    private static int kulcsfolyoso;

    public Image black;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtThedoor == true && kulcsfolyoso == 2)
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
            kulcsfolyoso = KulcsFolyoso.kulcsfolyoso;
            Debug.Log(kulcsfolyoso);
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
