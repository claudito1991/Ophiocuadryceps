using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungiMind : MonoBehaviour
{
    [SerializeField] private GameObject ant;
    [SerializeField] private Vector2 shooterPosition;
    [SerializeField] private GameObject bulletFungi;
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FungiFire();
        }
    }

    private Vector2 GetMousePosition2D()
    {
            Plane plane = new Plane(Vector3.back ,Vector3.zero);
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            plane.Raycast(Ray, out float distance);
            var point = Ray.origin + Ray.direction * distance;
            return point;
    }

    public void FungiFire()
    {
        var target = GetMousePosition2D();
        shooterPosition = ant.transform.position;
        var direction = (target - shooterPosition).normalized;
        Debug.DrawLine(target,target + direction, Color.green, 2f );
        var angle = Mathf.Atan2(direction.y, direction.x);
        Instantiate(bulletFungi, shooterPosition, Quaternion.Euler(0f,0f, angle * Mathf.Rad2Deg));
        Debug.Log($"{angle} - { (angle * Mathf.Rad2Deg)}");
    }



}

