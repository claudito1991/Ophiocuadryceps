using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject m_Prefab;
    [SerializeField] private float m_MinCooldown = 3f;
    [SerializeField] private float m_MaxCooldown = 6f;
    [SerializeField] private float m_AngleVariance = 20f;
    [SerializeField] private float m_SidewaysOffsetRange;

    private float spawnTime;

    private void ResetTimer() {
        spawnTime = Random.Range(m_MinCooldown, m_MaxCooldown);
    }

    private void Start() {
        ResetTimer();
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        
        if(spawnTime < 0)
        {
            ResetTimer();
            Spawn();
        }
    }

    private void Spawn()
    {
        var baseSpawnPosition = transform.position;
        var positionOffset = transform.up * GetRandomPosition();
        Vector3 spawnPosition = baseSpawnPosition + positionOffset;

        Quaternion baseSpawnerRotation = transform.rotation;
        Quaternion rotationOffset = Quaternion.Euler(0, 0, Random.Range(-m_AngleVariance, m_AngleVariance));
        Quaternion spawnRotation = rotationOffset* baseSpawnerRotation;

        Instantiate(m_Prefab, spawnPosition, spawnRotation);
    }


    private float GetRandomPosition() => Random.Range(-m_SidewaysOffsetRange,m_SidewaysOffsetRange);
}
