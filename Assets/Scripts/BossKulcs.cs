using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class BossKulcs : MonoBehaviour
{
    public static int kulcsBoss = 0;
    public int kulcsertek;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("key picked up");
            kulcsBoss = kulcsertek;
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        if (kulcsBoss == 3)
        {
            Destroy(this.gameObject);
        }
    }
}
