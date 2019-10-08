using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    [SerializeField] private LevelMgr LevelManager;
    [HideInInspector] public static GameMgr instance  = null;
    private enum State {INIT, PLAY, OVER};
    private State m_State;
    void Awake()
    {
        _SetState(State.INIT);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_State)
        {
            case State.PLAY:
                if (LevelManager.IsPass())
                    _NextLevel();
            break;

            case State.OVER:
            break;
        }
    }

    private void _NextLevel()
    {
        LevelManager.NextLevel();
    }

    private void _SetState(State s)
    {
        m_State = s;
        switch (m_State)
        {
            case State.INIT:
                // 
                if (instance == null)
                    instance = this;
                else if (instance != this)
                    Destroy(gameObject);
                //
                DontDestroyOnLoad(gameObject);
                //
                LevelManager.Init();
                //
                _SetState(State.PLAY);
            break;

            case State.PLAY:
            break;

            case State.OVER:
            break;
        }
    }
}
