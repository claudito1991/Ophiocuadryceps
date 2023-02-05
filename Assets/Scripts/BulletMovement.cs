using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float m_Speed = 20f;
    private Rigidbody2D rb2d;
    private FungiBullet bullet;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        bullet = GetComponent<FungiBullet>();
    }

    private void Update()
    {
        if(bullet.IsDead)
            rb2d.velocity = Vector2.zero;
        else
            rb2d.velocity = transform.right * m_Speed;
    }
}
