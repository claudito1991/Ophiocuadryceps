using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float m_Speed = 20f;
    private Rigidbody2D rb2d;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb2d.velocity = transform.right * m_Speed;
    }
}
