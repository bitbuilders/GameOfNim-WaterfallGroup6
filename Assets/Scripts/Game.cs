﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : Singleton<Game>
{
    public string m_player1Name;
    public string m_player2Name;
    public Difficulty Difficulty { get; set; }
    public GameMode GameMode { get; set; }
    static Game ms_instance = null;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (ms_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ms_instance = this;
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
