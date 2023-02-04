using UnityEngine;

public class AntCameraTarget : MonoBehaviour {
    private void Update() {
        if (!FungiMind.HasAnyPossessedAnts()) return;

        int count = FungiMind.GetPossessedAntCount();

        Vector3 position = Vector3.zero;

        for (int i = 0; i < count; i++) {
            var ant = FungiMind.GetAnt(i);

            position += ant.GetPosition();
        }

        position /= count;

        transform.position = position;
    }
}