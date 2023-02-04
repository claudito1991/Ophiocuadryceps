using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinAndLose : MonoBehaviour
{
    [SerializeField] private BoxCollider2D winCollider;
    [SerializeField] private GameObject[] spawns;
    private GameObject[] infectedAnts;

    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject loseText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForZeroInfected();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    if(other.GetComponent<Ant>().IsPossessed)
    {
        EverythingStop();
        winText.SetActive(true);
    }

    }



    private void RemoveControlFromPlayer(GameObject playerObject)
    {
        playerObject.GetComponent<AntMovement>().enabled = false;
        playerObject.GetComponent<AntDeath>().enabled = false;
    }

    private void EverythingStop()
    {
        infectedAnts = GameObject.FindGameObjectsWithTag("Ant");
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

    private void CheckForZeroInfected()
    {
        if (!FungiMind.HasAnyPossessedAnts())
        {
            EverythingStop();
            loseText.SetActive(true);
        }
        
    }
}
