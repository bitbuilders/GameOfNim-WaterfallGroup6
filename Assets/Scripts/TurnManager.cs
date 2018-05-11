using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnManager : Singleton<TurnManager> 
{
	[SerializeField] Text m_playerText;
	public Computer m_computer;
	public PlayerType m_playerType;
	
	public void NextTurn()
	{
		string curPlayerName = "";
		switch(m_playerType)
		{
			case PlayerType.PLAYER_1:
				m_playerType = PlayerType.PLAYER_2;
				curPlayerName = Game.Instance.m_player2Name;
				break;
			case PlayerType.PLAYER_2:
				m_playerType = PlayerType.PLAYER_1;
				curPlayerName = Game.Instance.m_player1Name;
				break;	
		}
		m_playerText.text = (curPlayerName + "'s Turn");
		if(m_playerType == PlayerType.PLAYER_2 && Game.Instance.GameMode == GameMode.PvC)
		{
			if(m_computer == null)
			{
				m_computer = (Computer)ScriptableObject.CreateInstance("Computer");
			}
			m_computer.MakeMove();
		}
	}
}
