using UnityEngine;

public class AntMovement : MonoBehaviour {
    [SerializeField] private float m_TurnSpeed = 30;
    [SerializeField] private float m_FollowRangeY = 1.5f;
    [SerializeField] private float m_MinSpeed = 0.8f;
    [SerializeField] private float m_MaxSpeed = 2.0f;

    private Ant ant;
    private Rigidbody2D rb2d;

    private bool isSlowedBySap;

    private void Awake() {
        ant = GetComponent<Ant>();
        rb2d = GetComponent<Rigidbody2D>();
        isSlowedBySap = false;
    }

    private float GetSpeedBlend() {
        if (!ant.IsPossessed) {
            return 0.0f;
        }

        var leaderAnt = FungiMind.GetLeaderAnt();

        if (leaderAnt == ant) {
            return 0.5f;
        }

        var deltaToLeader = leaderAnt.GetPosition() - ant.GetPosition();
        var normalizedDelta = Mathf.InverseLerp(-1, 1, deltaToLeader.y / m_FollowRangeY);
        return Mathf.Clamp01(normalizedDelta);
    }

    private void Update() {
        if (ant.IsPossessed) {
            rb2d.rotation = Mathf.MoveTowardsAngle(rb2d.rotation, 90, Time.deltaTime * m_TurnSpeed);
        }

        var targetSpeed = Mathf.Lerp(m_MinSpeed, m_MaxSpeed, GetSpeedBlend());
        var speedMultiplier = isSlowedBySap ? 0.5f : 1f;

        rb2d.velocity = transform.right * targetSpeed * speedMultiplier;
    }

    private void OnDisable() {
        Destroy(rb2d);
    }

    public bool AntInSap(bool state) {
        return isSlowedBySap = state;
    }
}