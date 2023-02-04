using UnityEngine;

public class AntCameraTarget : MonoBehaviour {
    private void Update() {
        if (!FungiMind.HasAnyPossessedAnts()) return;

        int count = FungiMind.GetPossessedAntCount();

        Vector2 min = Vector2.positiveInfinity;
        Vector2 max = Vector2.negativeInfinity;

        for (int i = 0; i < count; i++) {
            var ant = FungiMind.GetAnt(i);

            var position = ant.GetPosition();
            min = Vector2.Min(min, position);
            max = Vector2.Max(max, position);
        }

        transform.position = (min + max) / 2;
    }
}