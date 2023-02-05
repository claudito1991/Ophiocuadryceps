using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(200)]
public class CrosshairController : MonoBehaviour {
    [SerializeField] private RectTransform m_CrosshairTransform;

    private Camera mainCamera;
    private void Start() {
        mainCamera = Camera.main;
    }

    private void LateUpdate() {
        var pointerRay =mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane canvasPlane = new Plane(Vector3.back, transform.position);
        canvasPlane.Raycast(pointerRay, out float enter);

        var point = pointerRay.origin + pointerRay.direction * enter;

        m_CrosshairTransform.position = point;

        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
                Cursor.visible = true;
        }

        else
        {
                Cursor.visible = false;
        }

        
    }
}
