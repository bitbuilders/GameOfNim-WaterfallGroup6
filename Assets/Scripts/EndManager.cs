using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : Singleton<EndManager>
{
    [SerializeField] GameObject m_endPanel;

    public void GameOver()
    {
        m_endPanel.SetActive(true);
        Text text = GameObject.FindGameObjectWithTag("WinningText").GetComponent<Text>();
        if (TurnManager.Instance.m_playerType == PlayerType.PLAYER_1)
        {
            text.text = Game.Instance.m_player2Name + " has won the game!";
        }
        else
        {
            text.text = Game.Instance.m_player1Name + " has won the game!";
        }
    }

    public void End()
    {
        Game.Instance.LoadScene("MainMenu");
    }
}
