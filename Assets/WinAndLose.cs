using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAndLose : MonoBehaviour
{
    [SerializeField] private BoxCollider2D winCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    void OnTriggerStay(Collider other)
    {
            if(other.GetComponent<Ant>().IsPossessed)
        {
            RemoveControlFromPlayer(other.gameObject);
        }
    }

    private void RemoveControlFromPlayer(GameObject playerObject)
    {
        playerObject.GetComponent<AntMovement>().enabled = false;
        playerObject.GetComponent<AntDeath>().enabled = false;
    }
}
