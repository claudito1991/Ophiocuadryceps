
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnt : MonoBehaviour
{
    [SerializeField] private GameObject hormiga;
    [SerializeField] private float antSpeed = 0.5f;

    [SerializeField] private Rigidbody2D antRb;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        antRb.velocity = transform.up;
    }

}

