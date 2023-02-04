using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathSpeedManager : MonoBehaviour
{   
    public static Action<float> OnPopulationGrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(FungiMind.GetPossessedAntCount());
    }

    void OnEnable()
    {
        FungiMind.AntAddedToSwarm += AntQuantityTracker;
    }

    private void AntQuantityTracker()
    {
        var amountDecrease = (100f - FungiMind.GetPossessedAntCount())/100f;
        OnPopulationGrow?.Invoke(amountDecrease);
    }

    void OnDisable()
    {
         FungiMind.AntAddedToSwarm -= AntQuantityTracker;
    }
}
