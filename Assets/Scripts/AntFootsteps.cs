using UnityEngine;
using Random = UnityEngine.Random;

public class AntFootsteps : MonoBehaviour
{
    private void Start() {
        GetComponent<AudioSource>().pitch = Random.Range(.9f, 1.1f);
    }
}
