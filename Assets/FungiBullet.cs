using UnityEngine;

public class FungiBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if (!col.CompareTag("Ant")) return;
        
        var ant = col.GetComponent<Ant>();
        
        if (ant.IsPossessed) return;
        
        ant.OnBulletHit();
        Destroy(gameObject);
    }
}
