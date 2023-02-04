using UnityEngine;

public class AntMovement : MonoBehaviour {
    [SerializeField] private float m_TurnSpeed = 30;
    [SerializeField] private float m_FollowRangeY = 1.5f;
    [SerializeField] private float m_MinSpeed = 0.8f;
    [SerializeField] private float m_MaxSpeed =2.0f;

    private Ant ant;
    private Rigidbody2D rb2d;

    private void Awake() {
        ant = GetComponent<Ant>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (ant.IsPossessed) {
            rb2d.rotation = Mathf.MoveTowardsAngle(rb2d.rotation, 90, Time.deltaTime * m_TurnSpeed);
        }

        float speedBlend;
        var leaderAnt = FungiMind.GetLeaderAnt();

        if (leaderAnt == ant || !ant.IsPossessed) {
            speedBlend = 0.5f;
        }
        else {
            var deltaToLeader = leaderAnt.GetPosition() - ant.GetPosition();
            var normalizedDelta = Mathf.InverseLerp(-1, 1, deltaToLeader.y / m_FollowRangeY);
            speedBlend = Mathf.Clamp01(normalizedDelta);
        }

        rb2d.velocity = transform.right * Mathf.Lerp(m_MinSpeed, m_MaxSpeed, speedBlend);
    }

    void OnDisable()
    {
        Destroy(rb2d);
    }
}