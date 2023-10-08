using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlinking : MonoBehaviour
{

    [SerializeField]
    [ColorUsage(true, true)] // El atributo ColorUsage permite especificar las opciones de color
    private Color startColor;
    private Ant thisAnt;
    [SerializeField]
    [ColorUsage(true, true)] // El atributo ColorUsage permite especificar las opciones de color
    private Color endColor;

    [Range(0,10)]
    public float speed = 1;

    public Color originalColor;

    Renderer ren;

    private void Awake() 
    {
        ren = GetComponentInChildren<Renderer>();
        thisAnt = GetComponent<Ant>();
        originalColor = ren.material.color;
    }

    private void Update() 
    {
        if(FungiMind.GetLeaderAnt()==thisAnt)
        {
            float lerpValue = Mathf.PingPong(Time.time * speed, 1);
            Color lerpedColor = Color.Lerp(startColor, endColor, lerpValue);
            ren.material.color = originalColor + lerpedColor;
        }

    }
}
