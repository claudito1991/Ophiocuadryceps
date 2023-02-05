using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTimeline : MonoBehaviour
{
    [UsedImplicitly]
    public void LoadAntatron() {
        SceneManager.LoadScene("Antatron");
    }
}
