
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnts : MonoBehaviour
{
    [SerializeField] private GameObject antToSpawn;
    [SerializeField]private float cooldown = 5f;
    private Vector3 spawnPosition;
    [SerializeField] private float rangeSpawnValue;


    private float spawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if(spawnTime > cooldown )
        {
            SpawnOverTime();
            spawnTime = 0;
        }
    }

    private void SpawnOverTime()
    {
        GameObject ant = Instantiate(antToSpawn);
        spawnPosition = transform.position;
        var offset = transform.up;
        ant.transform.position = spawnPosition + offset* RandomPosition();
        Quaternion rotationOfTheParentOfTheParent = transform.rotation;
        ant.transform.rotation = rotationOfTheParentOfTheParent;
    }


    private float RandomPosition()
    {
        float y;
        y = Random.Range(-rangeSpawnValue,rangeSpawnValue);
        return y;
    }
}
