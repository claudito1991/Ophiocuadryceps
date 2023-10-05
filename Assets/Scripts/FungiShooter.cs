using UnityEngine;
using UnityEngine.Serialization;

public class FungiShooter : MonoBehaviour {
    [FormerlySerializedAs("bulletFungi")] [SerializeField]
    private GameObject m_BulletPrefab;

    [SerializeField]
    private float m_Cooldown;

    private Camera mainCamera;
    private float lastShotTime;

    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        
        if(!FungiMind.HasAnyPossessedAnts()) return;

        UpdateLocation();
        
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.JoystickButton0)) {
            
            Shoot();
        }
    }

    private void UpdateLocation() => transform.position = FungiMind.GetLeaderAnt().GetPosition();

    private Vector2 GetProjectedMousePosition() {
        Plane plane = new Plane(Vector3.back, transform.position);
        var pointerRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        plane.Raycast(pointerRay, out var distance);
        var point = pointerRay.origin + pointerRay.direction * distance;
        return point;
    }

    private void Shoot() {
        if (HasCooldown()) return;

        lastShotTime = Time.unscaledTime;
        var target = CrosshairController.GetCrosshairPosition();
        Vector2 shooterPosition = transform.position;
        var direction = (target - shooterPosition).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x);
        Instantiate(m_BulletPrefab, shooterPosition, Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg));
    }
    private bool HasCooldown() => (Time.unscaledTime - lastShotTime)< m_Cooldown;
}