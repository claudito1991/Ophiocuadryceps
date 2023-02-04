
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnts : MonoBehaviour
{
    [SerializeField] private GameObject antToSpawn;
    [SerializeField]private float cooldown = 5f;
    [SerializeField] private Vector3 spawnPosition;
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
        GameObject ant = Instantiate(antToSpawn, this.transform);
        spawnPosition = transform.position;
        var offset = transform.up;
        ant.transform.position = spawnPosition + offset* RandomPosition();
    }


    private float RandomPosition()
    {
        float y;
        y = Random.Range(-5f,5f);
        return y;
    }
}
