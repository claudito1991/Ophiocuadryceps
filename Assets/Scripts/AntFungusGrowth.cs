using System.Collections;
using UnityEngine;

public class AntFungusGrowth : MonoBehaviour
{
    [SerializeField] private GameObject m_FungusGraphic;

    private Ant ant;

    private IEnumerator Start()
    {
        ant = GetComponentInParent<Ant>();

        yield return new WaitUntil(GetIsPossessed);
        m_FungusGraphic.SetActive(true);
    }

    private bool GetIsPossessed() => ant.IsPossessed;
}
