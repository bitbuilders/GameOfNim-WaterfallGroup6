using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Toggle m_easy = null;
    [SerializeField] Toggle m_meduim = null;
    [SerializeField] Toggle m_hard = null;
    [SerializeField] InputField m_p1Name = null;
    [SerializeField] InputField m_p2Name = null;
    public GameMode m_gameMode;

    public void SelectGameMode(string mode)
    {
        if (mode.ToLower() == GameMode.PvP.ToString().ToLower())
        {
            m_gameMode = GameMode.PvP;
        }
        else if (mode.ToLower() == GameMode.PvC.ToString().ToLower())
        {
            m_gameMode = GameMode.PvC;
        }
    }

    public void UpdateData()
    {
        SetGameData();
        SetTurnData();
        Game.Instance.LoadScene("MainGame");
    }

    private void SetGameData()
    {
        Game.Instance.GameMode = m_gameMode;

        Difficulty difficulty = Difficulty.EASY;
        if (m_easy.isOn) difficulty = Difficulty.EASY;
        else if (m_meduim.isOn) difficulty = Difficulty.MEDIUM;
        else if (m_hard.isOn) difficulty = Difficulty.HARD;
        Game.Instance.Difficulty = difficulty;
    }

    private void SetTurnData()
    {
        TurnManager.Instance.m_player1Name = m_p1Name.text;
        TurnManager.Instance.m_player2Name = m_p2Name.text;
    }
}
