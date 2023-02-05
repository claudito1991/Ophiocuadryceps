using Cinemachine;
using UnityEngine;

public class ExplosionImpulseEmitter : MonoBehaviour {
    [SerializeField] private float m_ImpulseForce;
    private void Start() {
        var source= GetComponent<CinemachineImpulseSource>();
        source.GenerateImpulse(m_ImpulseForce * Random.insideUnitCircle);
    }
}
