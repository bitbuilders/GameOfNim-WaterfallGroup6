using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class NewTestScript
{
    [UnityTest]
    public IEnumerator BM_EmptyFalse()
    {
        GameObject bead = Object.Instantiate(Resources.Load<GameObject>("Bubble"));
        GameObject heap = Object.Instantiate(Resources.Load<GameObject>("Coral"));
        
        GameObject obj = new GameObject("Bob");
        BoardManager boardManager = obj.AddComponent<BoardManager>();
        boardManager.Construct(heap, bead);

        Assert.AreEqual(boardManager.BoardIsEmpty, false);

        yield return null;
    }

    [UnityTest]
    public IEnumerator BM_EmptyTrue()
    {
        GameObject bead = Object.Instantiate(Resources.Load<GameObject>("Bubble"));
        GameObject heap = Object.Instantiate(Resources.Load<GameObject>("Coral"));
        
        GameObject obj = new GameObject("Bob");
        BoardManager boardManager = obj.AddComponent<BoardManager>();
        boardManager.Construct(heap, bead);

        for (int i = 0; i < boardManager.m_heaps.Count; ++i)
        {
            boardManager.m_heaps[i].Clear();
        }

        Assert.AreEqual(boardManager.BoardIsEmpty, true);

        yield return null;
    }

    [UnityTest]
    public IEnumerator BM_CreateBoard()
    {
        GameObject bead = Object.Instantiate(Resources.Load<GameObject>("Bubble"));
        GameObject heap = Object.Instantiate(Resources.Load<GameObject>("Coral"));
        
        GameObject obj = new GameObject("Bob");
        GameObject obj2 = new GameObject("Bob2");
        Game game = obj2.AddComponent<Game>();
        game.Difficulty = Difficulty.MEDIUM;
        BoardManager boardManager = obj.AddComponent<BoardManager>();
        boardManager.Construct(heap, bead);

        Assert.AreEqual(boardManager.m_heaps.Count, 3);
        Assert.AreEqual(boardManager.m_heaps[0].Count, 2);
        Assert.AreEqual(boardManager.m_heaps[1].Count, 5);
        Assert.AreEqual(boardManager.m_heaps[2].Count, 7);

        yield return null;
    }

    [UnityTest]
    public IEnumerator BM_ValidHeap()
    {
        GameObject bead = Object.Instantiate(Resources.Load<GameObject>("Bubble"));
        GameObject heap = Object.Instantiate(Resources.Load<GameObject>("Coral"));
        
        GameObject obj = new GameObject("Bob");
        GameObject obj2 = new GameObject("Bob2");
        Game game = obj2.AddComponent<Game>();
        game.Difficulty = Difficulty.MEDIUM;
        BoardManager boardManager = obj.AddComponent<BoardManager>();
        boardManager.Construct(heap, bead);

        Assert.AreEqual(boardManager.IsValidHeap(0), true);
        boardManager.m_heaps[0].Clear();
        Assert.AreEqual(boardManager.IsValidHeap(0), false);

        yield return null;
    }

    [UnityTest]
    public IEnumerator BM_BeadCount()
    {
        GameObject bead = Object.Instantiate(Resources.Load<GameObject>("Bubble"));
        GameObject heap = Object.Instantiate(Resources.Load<GameObject>("Coral"));
        
        GameObject obj = new GameObject("Bob");
        GameObject obj2 = new GameObject("Bob2");
        Game game = obj2.AddComponent<Game>();
        game.Difficulty = Difficulty.MEDIUM;
        BoardManager boardManager = obj.AddComponent<BoardManager>();
        boardManager.Construct(heap, bead);

        Assert.AreEqual(boardManager.BeadCountInHeap(0), 2);
        Assert.AreEqual(boardManager.BeadCountInHeap(1), 5);
        Assert.AreEqual(boardManager.BeadCountInHeap(2), 7);

        yield return null;
    }

    [UnityTest]
    public IEnumerator BM_GetSelected()
    {
        GameObject bead = Object.Instantiate(Resources.Load<GameObject>("Bubble"));
        GameObject heap = Object.Instantiate(Resources.Load<GameObject>("Coral"));
        
        GameObject obj = new GameObject("Bob");
        GameObject obj2 = new GameObject("Bob2");
        Game game = obj2.AddComponent<Game>();
        game.Difficulty = Difficulty.MEDIUM;
        BoardManager boardManager = obj.AddComponent<BoardManager>();
        boardManager.Construct(heap, bead);

        Assert.AreEqual(boardManager.GetSelectedBeads().Count, 0);
        boardManager.m_heaps[1][3].Select();
        boardManager.m_heaps[2][5].Select();
        Assert.AreEqual(boardManager.GetSelectedBeads().Count, 2);

        yield return null;
    }

    [UnityTest]
    public IEnumerator RM_RemoveSelected()
    {
        GameObject bead = Object.Instantiate(Resources.Load<GameObject>("Bubble"));
        GameObject heap = Object.Instantiate(Resources.Load<GameObject>("Coral"));
        
        GameObject obj = new GameObject("Bob");
        GameObject obj2 = new GameObject("Bob2");
        RemoveManager removeManager = obj2.AddComponent<RemoveManager>();
        BoardManager boardManager = obj.AddComponent<BoardManager>();
        boardManager.Construct(heap, bead);

        Assert.AreEqual(boardManager.m_heaps[1].Count, 5);
        Assert.AreEqual(boardManager.m_heaps[2].Count, 7);
        boardManager.m_heaps[1][3].Select();
        boardManager.m_heaps[2][5].Select();
        removeManager.RemoveSelectedBeads();
        yield return new WaitForSeconds(2.0f);

        Assert.AreEqual(boardManager.m_heaps[1].Count, 4);
        Assert.AreEqual(boardManager.m_heaps[2].Count, 6);
    }

    [UnityTest]
    public IEnumerator TM_NextTurn()
    {
        GameObject obj = new GameObject("Bob");
        TurnManager turnManager = obj.AddComponent<TurnManager>();
        turnManager.Construct(new GameObject().AddComponent< UnityEngine.UI.Text>(), ScriptableObject.CreateInstance<Computer>());

        Assert.AreEqual(turnManager.m_playerType, PlayerType.PLAYER_1);
        turnManager.NextTurn();
        Assert.AreEqual(turnManager.m_playerType, PlayerType.PLAYER_2);

        yield return null;
    }

    [UnityTest]
    public IEnumerator BD_Select()
    {
        GameObject obj = Object.Instantiate(Resources.Load<GameObject>("Bubble"));
        Bead bead = obj.AddComponent<Bead>();

        Assert.AreEqual(bead.Selected, false);
        bead.Select();
        Assert.AreEqual(bead.Selected, true);
        bead.Select();
        Assert.AreEqual(bead.Selected, false);

        yield return null;
    }

    [UnityTest]
    public IEnumerator BD_DeSelect()
    {
        GameObject obj = Object.Instantiate(Resources.Load<GameObject>("Bubble"));
        Bead bead = obj.AddComponent<Bead>();

        Assert.AreEqual(bead.Selected, false);
        bead.Select();
        Assert.AreEqual(bead.Selected, true);
        bead.DeSelect();
        Assert.AreEqual(bead.Selected, false);

        yield return null;
    }

    [UnityTest]
    public IEnumerator CMP_MakeMove()
    {
        GameObject bead = Object.Instantiate(Resources.Load<GameObject>("Bubble"));
        GameObject heap = Object.Instantiate(Resources.Load<GameObject>("Coral"));

        GameObject obj = new GameObject("Bob");
        GameObject obj3 = new GameObject("Bob3");
        BoardManager boardManager = obj.AddComponent<BoardManager>();
        Game game = obj3.AddComponent<Game>();
        game.Difficulty = Difficulty.EASY;
        boardManager.Construct(heap, bead);

        Computer computer = ScriptableObject.CreateInstance<Computer>();

        int totalBeads = boardManager.m_heaps[0].Count + boardManager.m_heaps[1].Count;
        computer.MakeMove();
        yield return new WaitForSeconds(3.0f);

        int newBeads = boardManager.m_heaps[0].Count + boardManager.m_heaps[1].Count;
        Assert.AreNotEqual(totalBeads, newBeads);
    }
}
