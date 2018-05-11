using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnManager : Singleton<TurnManager> 
{
	public string m_player1Name;
	public string m_player2Name;
	[SerializeField] Text m_playerText;
	public Computer m_computer;
	private PlayerType m_playerType;
	
	public void NextTurn()
	{
		string curPlayerName = "";
		switch(m_playerType)
		{
			case PlayerType.PLAYER_1:
				m_playerType = PlayerType.PLAYER_2;
				curPlayerName = m_player1Name;
				break;
			case PlayerType.PLAYER_2:
				m_playerType = PlayerType.PLAYER_1;
				curPlayerName = m_player2Name;
				break;	
		}
		m_playerText.text = (curPlayerName + "'s Turn");
	}
}
