using UnityEngine;

public class AntSFX : MonoBehaviour {
    [SerializeField] private AudioSource m_PossessionSource;

    public void PlayPossessionSFX() {
        m_PossessionSource.Play();
    }
}
