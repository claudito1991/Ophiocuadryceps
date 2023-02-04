using System.Collections;
using UnityEngine;

public class AntDeath : MonoBehaviour {
    private Ant ant;
    [SerializeField] private float m_MinLifespan;
    [SerializeField] private float m_MaxLifespan;

    void Start() {
        ant = GetComponent<Ant>();  
    }

    void OnEnable()
    {
       StartCoroutine(TimerXD());
    }
    IEnumerator TimerXD() {
        yield return new WaitForSeconds(Random.Range(m_MinLifespan, m_MaxLifespan));
        Debug.Log("muerte");
        Destroy(gameObject);
    }
}