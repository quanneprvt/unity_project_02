using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMechanic : MonoBehaviour
{
    public enum MoveType{ Straight,  Circle};
    [SerializeField] private MoveType m_Type;
    [SerializeField] private float m_Speed;
    [SerializeField] private Vector3 m_StartPos;
    [SerializeField] private Vector3 m_EndPos;
    [SerializeField] private bool m_IsLoop = false;
    private float m_Step = 0f;
    private Vector3 m_Temp;
    private enum State{ Move, Stop };
    private State m_State;
    // Start is called before the first frame update
    void Start()
    {
        switch (m_Type)
        {
            case MoveType.Straight:
                if (m_StartPos == Vector3.zero)
                    m_StartPos = transform.position;
                m_Temp = m_StartPos;
            break;

            case MoveType.Circle:
            break;
        }
        _SetState(State.Move);
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_State)
        {
            case State.Move:
                m_Step = Math.Max(m_Step + Time.deltaTime * m_Speed, 0);
                transform.position = Vector3.MoveTowards(m_StartPos, m_EndPos, m_Step);
            break;

            case State.Stop:
                if (m_IsLoop)
                    _SetState(State.Move);
            break;
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        switch (m_Type)
        {
            case MoveType.Straight:
                if (Vector3.Distance(transform.position, m_EndPos) < 0.001f)
                {
                    if (m_EndPos == m_Temp)
                    {
                        if (m_IsLoop)
                           _Reverse();
                        else
                            _SetState(State.Stop);
                    }
                    else
                        _Reverse();
                }
            break;

            case MoveType.Circle:
            break;
        }
    }

    //Private
    private void _SetState(State s)
    {
        m_State = s;
    }

    private void _Reverse()
    {
        m_Step = 0;
        _Swap(ref m_StartPos, ref m_EndPos);
    }

    private void _Swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }
}
