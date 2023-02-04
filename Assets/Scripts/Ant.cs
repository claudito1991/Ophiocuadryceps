using UnityEngine;

public class Ant : MonoBehaviour {
    [SerializeField] private int m_StartingHitPoints = 3;
    private AntDeath antDeath;

    public bool IsPossessed { get; private set; }

    private AntMovement movement;
    private int hitPoints;

    private void Awake() {
        movement = GetComponent<AntMovement>();
        antDeath = GetComponent<AntDeath>();
        
    }

    private void Start() {
        hitPoints = m_StartingHitPoints;
        
        
    }

    private void OnDestroy() {
        if (IsPossessed) {
            FungiMind.UnregisterPossessedAnt(this);
        }
    }



    public void OnBulletHit() {
        if (IsPossessed) return;

        hitPoints--;
        if (hitPoints <= 0)
            Possess();
    }

    public void Possess() {
        if (!IsPossessed) {
            IsPossessed = true;
            antDeath.enabled =true;
            FungiMind.RegisterPossessedAnt(this);
        }
    }

    public Vector3 GetPosition() => transform.position;

}