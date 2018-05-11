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
                DeSelect();
            }
        }
    }
}
