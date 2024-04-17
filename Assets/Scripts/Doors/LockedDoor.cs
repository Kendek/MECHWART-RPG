using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour
{
    public GameObject player;
    public bool PlayerIsAtThedoor;
    public string sceneName;
    public string nyertScene;

    public Vector2 playerPosition;
    public VectorValue playerStorage;
    private static int kulcs;

    public Image black;
    public Animator anim;

    void Start()    
    {

    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtThedoor == true && kulcs == 1)
        {
            changeScene();
        }
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtThedoor == true && kulcs == 1 && PlayerController.Fight2Win ==1)
        {
            ChangeFaded();
        }
    }

    public void changeScene()
    {
        StartCoroutine(Fading());
    }
    public void ChangeFaded()
    {
        StartCoroutine(Faded());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            kulcs = CollisionDetector.kulcskonyvtar;
            Debug.Log(kulcs);
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
    IEnumerator Faded()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(nyertScene);
    }
}
