using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteScript : MonoBehaviour
{
    public Sprite playerPrefabs1;
    public Sprite playerPrefabs2;
    public Sprite playerPrefabs3;
    public Sprite playerPrefabs4;
    public SpriteRenderer spriteRenderer;
    int characterIndex;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        if (characterIndex == 0)
        {
            spriteRenderer.sprite = playerPrefabs1;
        }
        else if (characterIndex == 1)
        {
            spriteRenderer.sprite = playerPrefabs2;
        }
        else if (characterIndex == 2)
        {
            spriteRenderer.sprite = playerPrefabs3;
        }
        else if (characterIndex == 3)
        {
            spriteRenderer.sprite = playerPrefabs4;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
