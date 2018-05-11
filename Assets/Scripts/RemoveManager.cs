using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveManager : Singleton<RemoveManager>
{
    public void RemoveSelectedBeads()
    {
        if (HasSelectedBead())
        {
            BoardManager boardManager = BoardManager.Instance;
            boardManager.Locked = true;
            StartCoroutine(PopBeads(boardManager.GetSelectedBeads()));

            if (boardManager.BoardIsEmpty)
            {
                EndGame();
            }
            else
            {
                NextTurn();
            }
        }
    }

    private IEnumerator PopBeads(List<Bead> beads)
    {
        BoardManager boardManager = BoardManager.Instance;
        int beadCount = beads.Count;
        for (int i = 0; i < beadCount; ++i)
        {
            boardManager.m_heaps[beads[0].Heap].Remove(beads[0]);
            Destroy(beads[0].gameObject);
            beads.Remove(beads[0]);
            yield return new WaitForSeconds(0.1f);
        }
        
        BoardManager.Instance.Locked = false;
    }

    private void NextTurn()
    {
        TurnManager.Instance.NextTurn();
    }

    private void EndGame()
    {
        EndManager.Instance.GameOver();
    }

    private bool HasSelectedBead()
    {
        bool selectedOne = false;

        selectedOne = BoardManager.Instance.GetSelectedBeads().Count > 0;

        return selectedOne;
    }
}
