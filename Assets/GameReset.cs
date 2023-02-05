using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    public void ResetGame(){
        SceneManager.LoadScene(0);
    }
}
