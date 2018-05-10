using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
    public List<List<Bead>> m_heaps = null;
    [SerializeField] GameObject m_heapTemplate = null;
    [SerializeField] GameObject m_beadTemplate = null;
    public bool BoardIsEmpty { get; private set; }
    public bool Locked { get; set; }

    private void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {

    }

    private void CreateNewHeap(Vector2 position, Transform parent)
    {

    }

    private void CreateNewBeadInHeap(int heap)
    {

    }

    public bool IsValidHeap(int heap)
    {
        bool valid = false;

        return valid;
    }

    public int BeadCountInHeap(int heap)
    {
        int count = 0;

        return count;
    }

    public List<Bead> GetSelectedBeads()
    {
        List<Bead> selectedBeads = new List<Bead>();

        return selectedBeads;
    }
}
