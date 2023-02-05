using UnityEngine;
using UnityEngine.Serialization;

public class WinAndLose : MonoBehaviour {
    [FormerlySerializedAs("antSpawnRig")] [SerializeField]
    private GameObject m_AntSpawnRig;

    [FormerlySerializedAs("m_WinText")] [FormerlySerializedAs("winText")] [SerializeField]
    private GameObject m_WinTimeline;

    [FormerlySerializedAs("m_LoseText")] [FormerlySerializedAs("loseText")] [SerializeField]
    private GameObject m_LoseTimeline;

    [FormerlySerializedAs("inGameMenu")] [SerializeField]
    private GameObject m_IngameMenu;

    private void Start() {
        m_IngameMenu.SetActive(false);
    }

    private void Update() {
        CheckForZeroInfected();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            m_IngameMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Ant") || !other.GetComponent<Ant>().IsPossessed) {
            return;
        }

        Win();
    }


    private void RemoveControlFromPlayer(GameObject playerObject) {
        playerObject.GetComponent<AntMovement>().enabled = false;
        playerObject.GetComponent<AntDeath>().enabled = false;
    }

    private void StopEverything() {
        StopAllAnts();
        StopAntSpawners();
    }

    private void StopAntSpawners() {
        m_AntSpawnRig.SetActive(false);
    }

    private void StopAllAnts() {
        var allAnts = GameObject.FindGameObjectsWithTag("Ant");
        foreach (GameObject infectedAnt in allAnts) {
            if (infectedAnt != null) {
                RemoveControlFromPlayer(infectedAnt);
            }
        }
    }

    private void CheckForZeroInfected() {
        if (FungiMind.HasAnyPossessedAnts()) return;
        Lose();
    }

    private void Lose() {
        StopEverything();
        m_LoseTimeline.SetActive(true);
    }

    private void Win() {
        StopEverything();
        m_WinTimeline.SetActive(true);
    }
}