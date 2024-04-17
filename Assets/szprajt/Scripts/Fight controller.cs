using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Fightcontroller : MonoBehaviour
{
    //Player stats from PlayerController script
    public GameObject Player;
    private PlayerController PlayerController;

    //Enemy stats from EnemyController script
    public GameObject Enemy;
    private EnemyController EnemyStats;

    //UIs

    public TextMeshProUGUI smallhp, bighp, smallmana, bigmana;
    public GameObject PlayerAttacks;
    public GameObject InventoryScreen;
    public GameObject EndGameWinMenu;
    public GameObject EndGameLoseMenu;
    public UnityEngine.UI.Image healthbar;
    public UnityEngine.UI.Image ManaPool;
    public UnityEngine.UI.Image EnemyHealth;
    public Animator PlayerAnimator;

    //Inventory buttons
    public UnityEngine.UI.Button SmallHP, BigHP, SmallMana, BigMana;

    private bool PlayersTurn = true;
    private bool win = false;

    private float PlayerDMGMultiplier = 1.0f;
    private IEnumerator coroutine;

    public string sceneName;
    public string kidoScene;

    private float speed = 3.0f;
    int characterIndex;


    void Start()
    {
        
        //Get Stats from scripts
        Player.transform.position = new Vector3(-13.0f, 0.0f, 0.0f);

        PlayerAttacks.SetActive(false);
        EndGameLoseMenu.SetActive(false);
        InventoryScreen.SetActive(false);
        EndGameWinMenu.SetActive(false);
        PlayerController = Player.GetComponent<PlayerController>();
        EnemyStats = Enemy.GetComponent<EnemyController>();

        //Different Potions
        SmallHP.onClick.AddListener(delegate { PotionUsage("SmallHp"); });
        BigHP.onClick.AddListener(delegate { PotionUsage("BigHp"); });
        SmallMana.onClick.AddListener(delegate { PotionUsage("SmallMana"); });
        BigMana.onClick.AddListener(delegate { PotionUsage("BigMana"); });
         
        //Start Game Cycle after 2.5 sec
        Invoke("StartGameCycle", 2.5f);
    }

    void Update()
    {
        //Update UI

        EnemyHealth.fillAmount = EnemyStats.health / 100.0f;
        ManaPool.fillAmount = PlayerController.mana / PlayerController.maxmana;
        healthbar.fillAmount = PlayerController.health / PlayerController.maxhealth;

        //Potion Numbers
        smallhp.text = PlayerController.SmallHpPotion.ToString();
        bighp.text = PlayerController.BigHpPotion.ToString();
        smallmana.text = PlayerController.SmallManaPotion.ToString();
        bigmana.text = PlayerController.BigManaPotion.ToString();

        //Player coming in at the beggining 
        var step = speed * Time.deltaTime;
        Vector3 target = new Vector3(-6.69f, -1.0f, 0.0f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target, step);

        //Dosen't let Player or Enemys Health go under 100
        if (PlayerController.health <= 0)
            PlayerController.health = 0;
        if (EnemyStats.health <= 0)
            EnemyStats.health = 0;

    }

    //Start of the Game
    public void StartGameCycle()
    {
        PlayerAttacks.SetActive(true);
        coroutine = PlayersRound();
        StartCoroutine(coroutine);
    }
    //Rounds
    public void EnemysRound()
    {
        EnemyAttack();
    }

    IEnumerator PlayersRound()
    {
        PlayerAttacks.SetActive(true);
        while(PlayersTurn)
        {
            yield return null;
        }
        Debug.Log("Players Round is over");
        PlayerAttacks.SetActive(false);
        DeathCheck();
    }

    //Attacks

    //Neutral (0 mana)
    public void Slap()
    {
        float PlayerRandom = Random.Range(0.5f, 1.0f);
        EnemyStats.health -= Mathf.Round(PlayerController.strenght * PlayerRandom * PlayerDMGMultiplier);
        PlayersTurn = false;
        DeathCheck();
    }

    //Light Attack
    public void Ranged1()
    {
        if(PlayerController.mana >= 17 * PlayerController.dexterity / 10)
        {
            float PlayerRandom = Random.Range(0.8f, 1.2f);
            EnemyStats.health -= Mathf.Round(PlayerController.strenght * PlayerRandom * PlayerDMGMultiplier);
            PlayerController.mana -= Mathf.Round(17 * PlayerController.dexterity / 10);
            PlayersTurn = false;
            DeathCheck();
        }
        else
        {
            PlayersTurn=true;
            coroutine = PlayersRound();
            StartCoroutine(coroutine);
        }
    }
    //Heavy Attack

    public void Ranged2()
    {
        if(PlayerController.mana >= 27 * PlayerController.dexterity / 10)
        {
            float PlayerRandom = Random.Range(1.4f, 1.8f);
            EnemyStats.health -= Mathf.Round(PlayerController.strenght * PlayerRandom * PlayerDMGMultiplier);
            PlayerController.mana -= Mathf.Round(27 * PlayerController.dexterity / 10);
            PlayersTurn = false;
            DeathCheck();
        }
        else
        {
            PlayersTurn=true;
            coroutine = PlayersRound();
            StartCoroutine(coroutine);
        }
        
        
    }

    //Basic enemy attack
    public void EnemyAttack()
    {
        PlayerAnimator.Play("Base Layer.Player");
        float EnemyRandom = Random.Range(0.8f, 2.0f); 
        PlayerController.health -= Mathf.Round(EnemyStats.strenght * EnemyRandom);
        PlayersTurn = true;
        coroutine = PlayersRound();
        //You lost
        if (PlayerController.health <= 0)
        {
            win = false;
            EndScreen();
        }
        else
         StartCoroutine(coroutine);
    }

    //check if player is dead
    public void DeathCheck()
    {
        if (EnemyStats.health <= 0)
        {
            win = true;
            EndScreen();
        }
        else
        {
            EnemysRound();
        }
    }

    //Inventory Section
    public void InventoryOpen()
    {
        PlayerAttacks.SetActive(false);
        InventoryScreen.SetActive(true);
    }
    public void InventoryClose()
    {
        PlayerAttacks.SetActive(true);
        InventoryScreen.SetActive(false);
    }

    public void PotionUsage(string PotionVariant)
    {
        


        switch (PotionVariant)
            {
            case "SmallHp":
                if(PlayerController.SmallHpPotion > 0 && PlayerController.health != 100)
                {
                    if(PlayerController.health + 25 <= 100)
                    {
                        PlayerController.health += 25;
                        PlayerController.SmallHpPotion--;
                    }
                    else
                    {
                        PlayerController.health += 100 - PlayerController.health;
                        PlayerController.SmallHpPotion--;
                    }
                }
                break;
            case "BigHp":
                if (PlayerController.BigHpPotion > 0 && PlayerController.health != 100)
                {

                    if (PlayerController.health + 50 <= 100)
                    {
                        PlayerController.health += 50;
                        PlayerController.BigHpPotion--;
                    }
                    else
                    {
                        PlayerController.health += 100 - PlayerController.health;
                        PlayerController.BigHpPotion--;
                    }
                }
                break;

                
            case "SmallMana":
                if (PlayerController.SmallManaPotion > 0 && PlayerController.mana != 100)
                {

                    if (PlayerController.mana + 25 <= 100)
                    {
                        PlayerController.mana += 25;
                        PlayerController.SmallManaPotion--;
                    }
                    else
                    {
                        PlayerController.mana += 100 - PlayerController.mana;
                        PlayerController.SmallManaPotion--;
                    }
                }
                break;
            case "BigMana":
                if (PlayerController.BigManaPotion > 0 && PlayerController.mana != 100)
                {
                    if (PlayerController.mana + 50 <= 100)
                    {
                        PlayerController.mana += 50;
                        PlayerController.BigManaPotion--;
                    }
                    else
                    {
                        PlayerController.mana += 100 - PlayerController.mana;
                        PlayerController.BigManaPotion--;
                    }
                }
                break;
            }
    }



    //End of the game screen
    public void EndScreen()
    {
        if(win == false)
        {
            SceneManager.LoadScene(kidoScene);
            PlayerController.health = PlayerController.maxhealth;
            PlayerController.mana = PlayerController.maxmana;
            PlayerMovement.speed = 5f;
        }
        if(win ==true)
        {
            PlayerController.xp += 50;
            PlayerController.coin += 100;
            PlayerController.health = PlayerController.maxhealth;
            PlayerController.mana = PlayerController.maxmana;
            if (SceneManager.GetActiveScene().name == "Fight1")
            {
                PlayerController.Fight1Win = 1;
            }
            if (SceneManager.GetActiveScene().name == "Fight2")
            {
                PlayerController.Fight2Win = 1;
            }
            if (SceneManager.GetActiveScene().name == "Fight3")
            {
                PlayerController.Fight3Win = 1;
            }
            if (SceneManager.GetActiveScene().name == "Fight4")
            {
                PlayerController.Fight4Win = 1;
            }
            SceneManager.LoadScene(sceneName);
            EndGameWinMenu.SetActive(true);
        }
    }
}
