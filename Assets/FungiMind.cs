using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FungiMind : MonoBehaviour {
    private static readonly List<Ant> PossessedAnts = new();

    public static bool HasAnyPossessedAnts() {
        return PossessedAnts.Count > 0;
    }
    
    public static Ant GetFirstPossessedAnt() {
        return PossessedAnts.FirstOrDefault();
    }

    public static void RegisterPossessedAnt(Ant ant) {
        PossessedAnts.Add(ant);
    }

    public static void UnregisterPossessedAnt(Ant ant) {
        PossessedAnts.Remove(ant);
    }
}