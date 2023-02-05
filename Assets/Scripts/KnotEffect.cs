using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnotEffect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ant"))
        {
            Destroy(other.gameObject);
        }
    }
}
