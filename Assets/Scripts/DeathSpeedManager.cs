using UnityEngine;
using System;

public class DeathSpeedManager : MonoBehaviour
{   
    public static Action<float> OnPopulationGrow;

    [SerializeField] private float m_amountDecreaseModifier;
    private float amountDecrease;

    private void Start()
    {
        amountDecrease = 1f;
    }

    private void OnEnable()
    {
        FungiMind.AntAddedToSwarm += AntQuantityTracker;
    }

    private void AntQuantityTracker()
    {
        if(amountDecrease> 0.2f)
        {
         amountDecrease -= ((FungiMind.GetPossessedAntCount()) * m_amountDecreaseModifier)/100f;
        //Debug.Log("amount " + amountDecrease+ " count " + FungiMind.GetPossessedAntCount());
        OnPopulationGrow?.Invoke(amountDecrease);           
        }
        else
        {
            amountDecrease = 0.2f;
        }

    }

    void OnDisable()
    {
        FungiMind.AntAddedToSwarm -= AntQuantityTracker;
    }
}
