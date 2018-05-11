using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bead : MonoBehaviour
{
    public bool Selected { get; private set; }
    public int Heap { get; set; }

    public void Select()
    {
        Selected = !Selected;
        if (Selected)
        {
            SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
            if (TurnManager.Instance.m_playerType == PlayerType.PLAYER_1)
            {
                renderer.color = new Color(0, 255.0f / 255.0f, 78.0f / 255.0f);
            }
            else
            {
                renderer.color = new Color(255.0f / 255.0f, 78.0f / 255.0f, 53.0f / 255.0f);
            }
        }
        else
        {
            SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
            renderer.color = new Color(0.0f, 243.0f / 255.0f, 255.0f / 255.0f);
        }
    }

    public void DeSelect()
    {
        Selected = false;
    }

    private void OnMouseDown()
    {
        if (!BoardManager.Instance.Locked)
        {
            List<Bead> selected = BoardManager.Instance.GetSelectedBeads();
            Select();
            if (selected.Count > 0 && selected[0].Heap != Heap)
            {
                Select();
            }
        }
    }
}
