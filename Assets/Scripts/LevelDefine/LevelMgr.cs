using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMgr : MonoBehaviour
{
    [SerializeField] private int m_CurrentLevelIndex = 0;
    [SerializeField] private GameLevel[] m_Levels;
    private enum State { INIT, PLAY };
    private State m_State;
    private GameLevel m_CurrentLevel;
    private bool m_IsPass = false;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    public void Start()
    {
        _SetState(State.PLAY);
    }

    // Update is called once per frame
    public void Update()
    {
        switch (m_State)
        {
            case State.INIT:
                // if (m_CurrentLevel.IsPass())
                //     m_IsPass = true;
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
                //
                SceneManager.LoadScene("Level_2", LoadSceneMode.Single);
                // _SetLevel(m_CurrentLevelIndex);
                //
            break;

            case State.PLAY:
                GameObject gameObject = GameObject.Find("GameLevel");
                // Debug.Log(gameObject);
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
