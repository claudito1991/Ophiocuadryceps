using System.Collections;
using UnityEngine;

public class AntDeath : MonoBehaviour {
    private Ant ant;
    [SerializeField] private float m_MinLifespan;
    [SerializeField] private float m_MaxLifespan;

    private Coroutine coroutine;

    void Start() {
        ant = GetComponent<Ant>();  
    }

    void OnEnable()
    {
       coroutine = StartCoroutine(TimerXD());
    }
    IEnumerator TimerXD() {
        yield return new WaitForSeconds(Random.Range(m_MinLifespan, m_MaxLifespan));
        Debug.Log("muerte");
        Destroy(gameObject);
    }

    void OnDisable()
    {
        if(coroutine !=null)
        {
            StopCoroutine(coroutine);
        }
    }
}