using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject m_Prefab;
    [SerializeField] private float m_MinCooldown = 3f;
    [SerializeField] private float m_MaxCooldown = 6f;
    [SerializeField] private float m_AngleVariance = 20f;
    [SerializeField] private float m_SidewaysOffsetRange;
    [SerializeField] private float m_yOffsetToViewport=1.0f;

    private float spawnTime;
    private Camera mainCamera;
    private void ResetTimer() {
        spawnTime = Random.Range(m_MinCooldown, m_MaxCooldown);
    }

    private void Start() {
        mainCamera = Camera.main;
        ResetTimer();
    }

    private void Update() {
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
        
        var viewportPosition = mainCamera.WorldToViewportPoint(spawnPosition);
        viewportPosition.y = Mathf.Max(m_yOffsetToViewport, viewportPosition.y);

        spawnPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

        Quaternion baseSpawnerRotation = transform.rotation;
        Quaternion rotationOffset = Quaternion.Euler(0, 0, Random.Range(-m_AngleVariance, m_AngleVariance));
        Quaternion spawnRotation = rotationOffset* baseSpawnerRotation;

        if(m_Prefab.CompareTag("Ant"))
        {
            Instantiate(m_Prefab, spawnPosition, spawnRotation);
        }

        else
        {
            Instantiate(m_Prefab, spawnPosition, Quaternion.identity);
        }
        
    }


    private float GetRandomPosition() => Random.Range(-m_SidewaysOffsetRange,m_SidewaysOffsetRange);
}
