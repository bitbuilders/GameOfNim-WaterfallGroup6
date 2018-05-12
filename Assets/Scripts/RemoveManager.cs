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
            List<Bead> selected = boardManager.GetSelectedBeads();
            boardManager.Locked = true;
            int count = 0;
            int removed = selected.Count;
            for (int i = 0; i < boardManager.m_heaps.Count; ++i)
            {
                count += boardManager.m_heaps[i].Count;
            }
            StartCoroutine(PopBeads(selected));
        }
    }

    private IEnumerator PopBeads(List<Bead> beads)
    {
        BoardManager boardManager = BoardManager.Instance;
        int beadCount = beads.Count;
        for (int i = 0; i < beadCount; ++i)
        {
            Animator anim = beads[0].gameObject.GetComponentInChildren(typeof(Animator)) as Animator;
            anim.SetBool("isPopped", true);
            Destroy(beads[0].gameObject, 1.0f);
            //Debug.Log(anim.GetBool("isPopped"));
            //Debug.Log(anim);
            boardManager.m_heaps[beads[0].Heap].Remove(beads[0]);
            beads.Remove(beads[0]);
            yield return null; //new WaitForSeconds(0.1f);
        }
        
        boardManager.Locked = false;
        if (boardManager.BoardIsEmpty)
        {
            EndGame();
        }
        else
        {
            NextTurn();
        }
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
