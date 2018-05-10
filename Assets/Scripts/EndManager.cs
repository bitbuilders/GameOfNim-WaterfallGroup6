using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : Singleton<EndManager>
{
    [SerializeField] GameObject m_endPanel;

    public void GameOver()
    {
        m_endPanel.SetActive(true);
    }
}
