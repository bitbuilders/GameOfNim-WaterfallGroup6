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
		
	}
}
