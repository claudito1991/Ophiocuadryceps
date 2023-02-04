using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAntzNotVisible : MonoBehaviour
{
    private bool antVisible;
    [SerializeField] private float timeToWaitIfNotConverted = 5f;
    // Start is called before the first frame update
    void Start()
    {
        var antVisible = GetComponent<Renderer>().isVisible;
        StartCoroutine(TimerXD());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        IEnumerator TimerXD() {
        yield return new WaitForSeconds(timeToWaitIfNotConverted);
        Destroy(gameObject);
    }
}