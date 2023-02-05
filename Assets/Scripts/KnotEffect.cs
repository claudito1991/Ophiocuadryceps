using UnityEngine;

public class KnotEffect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ant")) {
            var antDeath = other.GetComponent<AntDeath>();
            antDeath.ForceKill();
        }
    }
}
