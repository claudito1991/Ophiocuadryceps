using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntShadow : MonoBehaviour {
    [SerializeField] private Transform m_ReferenceTransform;
    [SerializeField] private Vector3 m_PositionOffset;

    private void LateUpdate() {
        if (m_ReferenceTransform) {
            transform.position = m_ReferenceTransform.position + m_PositionOffset;
        }
    }
}
