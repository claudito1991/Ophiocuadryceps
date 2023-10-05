using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(200)]
public class CrosshairController : MonoBehaviour {
    [SerializeField] private RectTransform m_CrosshairTransform;
    [SerializeField] private float m_ControllerRadius;
    private Camera mainCamera;

    private static bool useMouse;
    private Vector2 aimVector;
    private static Transform crosshair;

    public static Vector2 GetCrosshairPosition() => crosshair.position;

    private void Start() {
        mainCamera = Camera.main;
        crosshair = m_CrosshairTransform;
    }

    private void LateUpdate() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) useMouse = true;

        if (Input.GetKeyDown(KeyCode.JoystickButton0)) useMouse = false;

        if (useMouse) {
            var pointerRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane canvasPlane = new Plane(Vector3.back, transform.position);
            canvasPlane.Raycast(pointerRay, out float enter);

            var point = pointerRay.origin + pointerRay.direction * enter;

            m_CrosshairTransform.position = point;
        }
        else {
            var xInput = Input.GetAxisRaw("Horizontal");
            var yInput = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(xInput) > 0.1 || Mathf.Abs(yInput) > 0.1) {
                aimVector = new Vector2(xInput, yInput).normalized * m_ControllerRadius;
            }

            var leader = FungiMind.GetLeaderAnt();
            if (leader) {
                m_CrosshairTransform.position = leader.GetPosition() + (Vector3)aimVector;
            }
        }





        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        if (SceneManager.GetActiveScene().buildIndex == 0) {
            Cursor.visible = true;
        }

        else {
            Cursor.visible = false;
        }


    }
}
