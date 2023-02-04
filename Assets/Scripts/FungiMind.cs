using UnityEngine;
using UnityEngine.Serialization;

public class FungiMind : MonoBehaviour {
    [FormerlySerializedAs("ant")] [SerializeField]
    private GameObject m_StarterAnt;

    [FormerlySerializedAs("bulletFungi")] [SerializeField]
    private GameObject m_BulletPrefab;

    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private Vector2 GetProjectedMousePosition() {
        Plane plane = new Plane(Vector3.back, transform.position);
        var pointerRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        plane.Raycast(pointerRay, out var distance);
        var point = pointerRay.origin + pointerRay.direction * distance;
        return point;
    }

    private void Shoot() {
        var target = GetProjectedMousePosition();
        Vector2 shooterPosition = m_StarterAnt.transform.position;
        var direction = (target - shooterPosition).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x);
        Instantiate(m_BulletPrefab, shooterPosition, Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg));
    }
}