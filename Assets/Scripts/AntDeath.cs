using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AntDeath : MonoBehaviour {
    [SerializeField] private float m_MinLifespan;
    [SerializeField] private float m_MaxLifespan;
    [Space]
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Image m_TimerImage;
    [SerializeField] private GameObject m_DestroyEffect;
    private Coroutine coroutine;
    private static readonly int Shake = Animator.StringToHash("Shake");

    private bool timerCritical;
    
    private void OnEnable() {
        DeathSpeedManager.OnPopulationGrow += ReduceDeathTime;
    }

    private void Start() {
        m_TimerImage.canvasRenderer.SetColor(new(1, 1, 1, 0));
    }

    public void BeginTimer() {
        coroutine = StartCoroutine(TimerXd());
    }

    private IEnumerator TimerXd() {
        m_TimerImage.CrossFadeAlpha(1, 2f, true);
        float t = 0.0f;
        var duration = Random.Range(m_MinLifespan, m_MaxLifespan);

        while (t < duration) {
            t += Time.deltaTime;

            m_Animator.SetFloat(Shake, t / duration);
            m_TimerImage.fillAmount = 1.0f - t / duration;

            if (!timerCritical && t / duration > 0.8) {
                timerCritical = true;
                m_TimerImage.CrossFadeColor(Color.red, 0.3f, true, false);
            }

            yield return null;
        }
        Kill();
    }

    private void OnDisable() {
        if (coroutine != null) {
            StopCoroutine(coroutine);
        }
        DeathSpeedManager.OnPopulationGrow -= ReduceDeathTime;
    }

    private void ReduceDeathTime(float multiplier) {
        m_MaxLifespan *= multiplier;
        m_MinLifespan *= multiplier;
    }

    public void ForceKill() {
        Kill();
    }

    private void Kill() {
        Instantiate(m_DestroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
