using UnityEngine;

public class BackgroundController : MonoBehaviour {
    private Camera mainCamera;

    private void Start() {
        mainCamera  = Camera.main;
    }

    private void LateUpdate() {
        var position = transform.position;
        position.y = mainCamera.transform.position.y;
        transform.position = position;
    }
}
