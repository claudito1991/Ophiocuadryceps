using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntDeath : MonoBehaviour
{
    [SerializeField] private Ant ant;
    // Start is called before the first frame update

    void Start()
    {
        ant = GetComponent<Ant>();
    }
    void Update()
    {
        if(ant.IsPossessed && !ant.IsFirstAnt())
        {
            Destroy(this.gameObject);
        }
    }

}
