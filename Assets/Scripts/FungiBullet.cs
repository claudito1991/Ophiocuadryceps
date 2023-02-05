using System.Collections;
using UnityEngine;

public class FungiBullet : MonoBehaviour {
    [SerializeField] private float m_LifeSpan = 5;
    [SerializeField] private GameObject m_ImpactEffect;

    public bool IsDead { get; private set; }

    private void Start() {
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy() {
        yield return new WaitForSeconds(m_LifeSpan);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (IsDead) return;
        
        if (!col.CompareTag("Ant")) return;
        
        var ant = col.GetComponent<Ant>();
        
        if (ant.IsPossessed) return;
        
        ant.OnBulletHit();
        Kill();
    }

    private void Kill() {
        if (IsDead) return;
        
        IsDead = true;

        foreach (var ps in GetComponentsInChildren<ParticleSystem>()) {
            var emissionModule = ps.emission;
            emissionModule.enabled = false;
        }

        Instantiate(m_ImpactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.6f);
    }
}
