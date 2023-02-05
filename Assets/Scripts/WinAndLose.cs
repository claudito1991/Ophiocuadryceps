using UnityEngine;
using UnityEngine.Serialization;

public class WinAndLose : MonoBehaviour {
    [FormerlySerializedAs("antSpawnRig")] [SerializeField]
    private GameObject m_AntSpawnRig;

    [FormerlySerializedAs("winText")] [SerializeField]
    private GameObject m_WinText;

    [FormerlySerializedAs("loseText")] [SerializeField]
    private GameObject m_LoseText;

    private void Update() {
        CheckForZeroInfected();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Ant") || !other.GetComponent<Ant>().IsPossessed) {
            return;
        }

        EverythingStop();
        m_WinText.SetActive(true);
    }


    private void RemoveControlFromPlayer(GameObject playerObject) {
        playerObject.GetComponent<AntMovement>().enabled = false;
        playerObject.GetComponent<AntDeath>().enabled = false;
    }

    private void EverythingStop() {
        var allAnts = GameObject.FindGameObjectsWithTag("Ant");
        foreach (GameObject infectedAnt in allAnts) {
            if (infectedAnt != null) {
                RemoveControlFromPlayer(infectedAnt);
            }
        }

        m_AntSpawnRig.SetActive(false);
    }

    private void CheckForZeroInfected() {
        if (FungiMind.HasAnyPossessedAnts()) return;
        EverythingStop();
        m_LoseText.SetActive(true);
    }
}