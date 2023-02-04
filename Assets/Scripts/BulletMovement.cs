using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float fungiBulletForce = 2f;
    [SerializeField] private Rigidbody2D bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletRb.velocity = transform.right * fungiBulletForce;
        //transform.Translate(transform.right * Time.deltaTime * fungiBulletSpeed , Space.Self);
    }
}
