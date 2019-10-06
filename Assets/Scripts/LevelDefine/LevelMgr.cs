using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    [SerializeField] private int m_CurrentLevelIndex = 0;
    [SerializeField] private LevelDefine m_Levels;
    private static LevelMgr instance = null;
    private enum State { INIT, PLAY};
    private State m_State;
    private Level m_CurrentLevel;
    private bool m_IsPass = false;
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        switch (m_State)
        {
            case State.INIT:
                if (m_CurrentLevel.IsPass())
                    m_IsPass = true;
            break;

            case State.PLAY:
            break;
        }
    }

    public void Init()
    {
        _SetState(State.INIT);
    }

    public bool IsPass()
    {
        return m_IsPass;
    }

    public void NextLevel()
    {
        _SetLevel(m_CurrentLevelIndex += 1);
    }

    private void _SetState(State s)
    {
        m_State = s;
        switch (m_State)
        {
            case State.INIT:
                // Singleton
                if (instance == null)
                {
                    instance = this;
                    _SetLevel(m_CurrentLevelIndex);
                }
                //
            break;

            case State.PLAY:
            break;
        }
    }

    private void _SetLevel(int l)
    {
        if (m_CurrentLevelIndex >= m_Levels.Length)
        {
            Time.timeScale = 0;
            return;
        }
        m_CurrentLevel = m_Levels[l];
    }
}
