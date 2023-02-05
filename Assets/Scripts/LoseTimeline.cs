using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTimeline : MonoBehaviour
{
    [UsedImplicitly]
    public void ResetGame() {
        SceneManager.LoadScene(0);
    }
}
