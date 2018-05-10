using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public Difficulty difficulty { get; set; }
    public GameMode gameMode { get; set; }
    void Start()
    {

    }
    

    void LoadScene(string scene)
    {   
        SceneManager.LoadScene(scene);
    }

    void QuitGame()
    {
        Application.Quit();
    }

}
