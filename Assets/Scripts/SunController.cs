using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    //Vector to rotate 60,2,0
    [SerializeField] private Vector3 m_RotateAxis;
    [SerializeField] private float m_Speed;
    private float m_Step = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // m_Step += m_Speed * Time.deltaTime;
        transform.RotateAround(m_RotateAxis, transform.position, m_Speed/180 * (float)Math.PI);
    }
}
