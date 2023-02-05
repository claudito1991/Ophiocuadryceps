using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AntDeath : MonoBehaviour {
    [SerializeField] private float m_MinLifespan;
    [SerializeField] private float m_MaxLifespan;
    [Space]
    [SerializeField] private GameObject m_DestroyEffect;
    private Coroutine coroutine;

    private void OnEnable()
    {
       DeathSpeedManager.OnPopulationGrow += ReduceDeathTime;
       
    }

    void Start()
    {
        coroutine = StartCoroutine(TimerXd());
    }

    private IEnumerator TimerXd() {
        yield return new WaitForSeconds(Random.Range(m_MinLifespan, m_MaxLifespan));
        Instantiate(m_DestroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        if(coroutine !=null)
        {
            StopCoroutine(coroutine);
        }
        DeathSpeedManager.OnPopulationGrow -= ReduceDeathTime;
    }

    private void ReduceDeathTime(float multiplier)
    {
        m_MaxLifespan *= multiplier;
        m_MinLifespan *= multiplier;
    }
}