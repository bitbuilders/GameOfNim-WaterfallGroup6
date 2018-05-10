using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : Singleton<PauseManager> 
{
	[SerializeField] private GameObject m_pausePanel = null;

	/// <summary>
	/// Listens to Pause input button to toggle the state of m_pausePanel
	/// </summary>
	private void Update()
	{
		if(Input.GetButtonDown("Pause"))
		{
			TogglePause();
		}
	}

	/// <summary>
	/// Calls PauseGame with the opposite state of m_pausePanel.active, essentially toggling the paused state
	/// </summary>
	private void TogglePause()
	{
		bool curState = m_pausePanel.activeInHierarchy;
		PauseGame(!curState);
	}

	/// <summary>
	/// Sets m_pausePanel.active to state
	/// </summary>
	/// <param name="state">set m_pausePanel.active</param>
	private void PauseGame(bool state)
	{
		m_pausePanel.SetActive(state);
	}

}
