using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnts : MonoBehaviour
{
    [SerializeField] private GameObject antToSpawn;
    [SerializeField] private float spawnTime;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown > )
    }

    private void SpawnOverTime()
    {
        Instantiate(antToSpawn, transform);
    }
}
