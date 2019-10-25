using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject m_GameMgr;
    private class LevelObject <T>{
        public T LevelDefine;
    }
    // Start is called before the first frame update
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        //Instance GameMgr
        if (GameMgr.instance == null)
            Instantiate(m_GameMgr);
        //Load Json
        TextAsset t = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Scripts/LevelDefine/LevelDefine.json", typeof(TextAsset));
        object o = Utils.FromJson<object>(t.text);
        Debug.Log(o);
        DontDestroyOnLoad(gameObject);
    }
}
