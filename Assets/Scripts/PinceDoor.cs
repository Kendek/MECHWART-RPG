using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinceDoor : MonoBehaviour
{
    public GameObject player;
    public bool PlayerIsAtThedoor;
    public string sceneName;

    public Vector2 playerPosition;
    public VectorValue playerStorage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtThedoor == true)
            {
                changeScene();
            }
    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
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
}