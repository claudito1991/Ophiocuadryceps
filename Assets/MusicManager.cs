using UnityEngine;

public class MusicManager : MonoBehaviour {
    [SerializeField] private int m_LowIntensityBound = 2;
    [SerializeField] private int m_HighIntensityBound = 10;
    [SerializeField] private float m_IntensityBlendRate = 0.1f;

    private Animator animator;
    private static readonly int Blend = Animator.StringToHash("Blend");

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        var possessedCount=FungiMind.GetPossessedAntCount();
        var targetBlend = Mathf.InverseLerp(m_LowIntensityBound, m_HighIntensityBound, possessedCount);
        var blend = animator.GetFloat(Blend);
        animator.SetFloat(Blend, Mathf.MoveTowards(blend, targetBlend, m_IntensityBlendRate* Time.deltaTime));
    }
}
