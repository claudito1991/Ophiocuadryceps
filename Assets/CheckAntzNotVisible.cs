using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAntzNotVisible : MonoBehaviour
{
    private bool antVisible;
    [SerializeField] private float timeToWaitIfNotConverted = 3f;
    private Ant ant;
    [SerializeField]private bool readyToDie;
    // Start is called before the first frame update
    void Start()
    {
        readyToDie = false;
        ant = GetComponent<Ant>();
        StartCoroutine(TimerXD());
    }

    // Update is called once per frame
    void Update()
    {
        if(!ant.IsPossessed && readyToDie)
        {
            KillAntIfNotInCamera();
        }
        
    }

        IEnumerator TimerXD() {
        yield return new WaitForSeconds(timeToWaitIfNotConverted);
        readyToDie = true;
       
    }

    private void KillAntIfNotInCamera()
    {
        
        var antViewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if(antViewportPosition.y<-0.2f)
        {
            Debug.Log("Hormiga no esta en camara y es destruida", this);
            Destroy(gameObject);
        }
        
        // if (!antViewportPosition) 
        // {
        //     Debug.Log("Destroyed useless ant");
        //      Destroy(gameObject);
        // }
    }
}
