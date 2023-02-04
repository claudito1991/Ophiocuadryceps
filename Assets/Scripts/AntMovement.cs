using UnityEngine;

public class AntMovement : MonoBehaviour {
    [SerializeField] private float m_Speed = 0.5f;
    private Rigidbody2D rb2d;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        rb2d.velocity = transform.right * m_Speed;
    }
}