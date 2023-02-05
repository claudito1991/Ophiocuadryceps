using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapEffect : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Ant"))
        {
            other.GetComponent<AntMovement>().AntInSap(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
                if(other.CompareTag("Ant"))
        {
            other.GetComponent<AntMovement>().AntInSap(false);
        }
    }
}
