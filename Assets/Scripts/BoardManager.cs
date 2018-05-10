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
        Game game = Game.Instance;
        int heaps = 0;
        int[] beadsPerHeap = null;

        switch (game.Difficulty)
        {
            case Difficulty.EASY:
                heaps = 2;
                beadsPerHeap = new int[] { 3, 3 };
                break;
            case Difficulty.MEDIUM:
                heaps = 3;
                beadsPerHeap = new int[] { 2, 5, 7 };
                break;
            case Difficulty.HARD:
                heaps = 4;
                beadsPerHeap = new int[] { 2, 3, 8, 9 };
                break;
        }

        float x = -5.0f;
        float y = 0.0f;
        for (int i = 0; i < heaps; ++i)
        {
            GameObject heap = Instantiate(m_heapTemplate, new Vector3(x, y), Quaternion.identity, transform);
            float bX = 0.0f;
            float bY = 4.0f;
            for (int j = 0; j < beadsPerHeap[i]; ++j)
            {
                bY -= 2.0f;
                GameObject bubble = Instantiate(m_beadTemplate, Vector3.zero, Quaternion.identity, heap.transform);
                bubble.transform.localPosition = new Vector3(bX, bY);
            }
            x += 7.0f;
        }
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
