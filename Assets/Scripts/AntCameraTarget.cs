using UnityEngine;
using Cinemachine;

public class AntCameraTarget : MonoBehaviour {

    [SerializeField] private CinemachineVirtualCamera  vmCamera;
    [SerializeField] private float vmCamChangeSizeSpeed = 0.5f;
    [SerializeField] private float sizePercentChangePerAnt = 0.3f;
    [SerializeField] private float cameraMinSize = 5f;
    private int count;
    private void Update() {
        if (!FungiMind.HasAnyPossessedAnts()) return;

        count = FungiMind.GetPossessedAntCount();

        Vector2 min = Vector2.positiveInfinity;
        Vector2 max = Vector2.negativeInfinity;

        for (int i = 0; i < count; i++) {
            var ant = FungiMind.GetAnt(i);

            var position = ant.GetPosition();
            min = Vector2.Min(min, position);
            max = Vector2.Max(max, position);
        }

        transform.position = (min + max) / 2;
        if(count > 1)
        {
            UpdateLensOrthoSize();
        }
        
    }


    private void UpdateLensOrthoSize()
    {
        var previousSize = vmCamera.m_Lens.OrthographicSize;
        
        var targetSize = count * 5f * sizePercentChangePerAnt;
        if(targetSize > cameraMinSize)
        {
            vmCamera.m_Lens.OrthographicSize = Mathf.Lerp(previousSize, targetSize, vmCamChangeSizeSpeed*Time.deltaTime);
        }
       
        
    }
}