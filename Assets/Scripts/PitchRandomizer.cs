using UnityEngine;
using Random = UnityEngine.Random;

public class PitchRandomizer : MonoBehaviour {
    [SerializeField] private float m_MinPitch;
    [SerializeField] private float m_MaxPitch;
    private void Start() {
        GetComponent<AudioSource>().pitch = Random.Range(m_MinPitch,m_MaxPitch);
    }
}
