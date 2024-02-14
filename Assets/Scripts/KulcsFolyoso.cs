using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KulcsFolyoso : MonoBehaviour
{
    public static int kulcsfolyoso = 0;
    public int kulcsertek;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("key picked up");
            kulcsfolyoso = kulcsertek;

            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        if (kulcsfolyoso == 2)
        {
            Destroy(this.gameObject);
        }
    }
}
