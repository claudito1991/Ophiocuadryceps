using System.Collections;
using UnityEngine;

public class FungiBullet : MonoBehaviour {
    [SerializeField] private float m_LifeSpan = 5;

    private void Start() {
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy() {
        yield return new WaitForSeconds(m_LifeSpan);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (!col.CompareTag("Ant")) return;
        
        var ant = col.GetComponent<Ant>();
        
        if (ant.IsPossessed) return;
        
        ant.OnBulletHit();
        Destroy(gameObject);
    }
}
