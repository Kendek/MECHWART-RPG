using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class CollisionDetector : MonoBehaviour
{
    public static int kulcskonyvtar=0;
    public int kulcsertek;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("key picked up");
            kulcskonyvtar = kulcsertek;
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        if (kulcskonyvtar ==1)
        {
            Destroy(this.gameObject);
        }
    }
}