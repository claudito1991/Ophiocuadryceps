using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAndLose : MonoBehaviour
{
    [SerializeField] private BoxCollider2D winCollider;
    [SerializeField] private GameObject[] spawns;
    private GameObject[] infectedAnts;
    
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
    if(other.GetComponent<Ant>().IsPossessed)
      {
        infectedAnts = GameObject.FindGameObjectsWithTag("Ant");
      }

            
    foreach (GameObject infectedAnt in infectedAnts)
    {
    if(infectedAnt != null)
    {
        RemoveControlFromPlayer(infectedAnt);
    }
    
            
    }

        foreach (GameObject spawn in spawns)
        {
            spawn.SetActive(false);
        }
    }



    private void RemoveControlFromPlayer(GameObject playerObject)
    {
        playerObject.GetComponent<AntMovement>().enabled = false;
        playerObject.GetComponent<AntDeath>().enabled = false;
    }
}
