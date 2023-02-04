using System.Collections.Generic;
using UnityEngine;

public class FungiMind : MonoBehaviour {
    private static readonly List<Ant> PossessedAnts = new();

    private void Start() {
        var firstAnt = FindObjectOfType<Ant>();
        if (firstAnt) {
            firstAnt.Possess();
        }
    }

    public static bool HasAnyPossessedAnts() {
        return PossessedAnts.Count > 0;
    }

    public static Ant GetLeaderAnt() => PossessedAnts.Count > 0 ? PossessedAnts[0] : null;

    public static void RegisterPossessedAnt(Ant ant) {
        PossessedAnts.Add(ant);
    }

    public static void UnregisterPossessedAnt(Ant ant) {
        PossessedAnts.Remove(ant);
    }

    public static int GetPossessedAntCount() => PossessedAnts.Count;

    public static Ant GetAnt(int i) => PossessedAnts[i];
}