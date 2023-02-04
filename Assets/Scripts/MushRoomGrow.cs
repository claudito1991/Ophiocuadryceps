using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomGrow : MonoBehaviour
{
    private Ant ant;
    [SerializeField] private GameObject shroom;
    // Start is called before the first frame update
    void Start()
    {
        ant = GetComponentInParent<Ant>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ant.IsPossessed)
        {
            shroom.SetActive(true);
        }
    }
}
