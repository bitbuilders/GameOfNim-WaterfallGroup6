using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
    public List<List<Bead>> m_heaps = null;
    [SerializeField] GameObject m_heapTemplate = null;
    [SerializeField] GameObject m_beadTemplate = null;
    public bool BoardIsEmpty
    {
        get
        {
            for (int i = 0; i < m_heaps.Count; ++i)
            {
                if (m_heaps[i].Count > 1)
                    return false;
            }
            return true;
        }
        private set { }
    }
    public bool Locked { get; set; }

    private void Start()
    {
        m_heaps = new List<List<Bead>>();
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

        heaps = 4;
        beadsPerHeap = new int[] { 2, 3, 8, 9 };

        float x = -6.5f + (1.6f * (4 - heaps));
        float y = 0.0f;
        for (int i = 0; i < heaps; ++i)
        {
            GameObject heap = Instantiate(m_heapTemplate, new Vector3(x, y), Quaternion.identity, transform);
            float bX = 0.0f;
            float bY = 4.3f - (0.25f * (9 - beadsPerHeap[i]));
            m_heaps.Add(new List<Bead>());
            for (int j = 0; j < beadsPerHeap[i]; ++j)
            {
                GameObject bubble = Instantiate(m_beadTemplate, Vector3.zero, Quaternion.identity, heap.transform);
                bubble.transform.localPosition = new Vector3(bX, bY);
                Bead bead = bubble.GetComponent<Bead>();
                bead.DeSelect();
                bead.Heap = i;
                m_heaps[i].Add(bead);

                bY -= 1.1f + (0.1f * (9 - beadsPerHeap[i]));
                bX = Random.Range(-1.0f, 1.0f);
            }
            x += 4.3f + (1.0f * (4 - heaps));
        }
    }

    private void CreateNewHeap(Vector2 position, Transform parent)
    {

    }

    private void CreateNewBeadInHeap(int heap)
    {
        Game.Instance.QuitGame();
    }

    public bool IsValidHeap(int heap)
    {
        bool valid = false;

        valid = m_heaps[heap].Count > 0;

        return valid;
    }

    public int BeadCountInHeap(int heap)
    {
        int count = 0;

        count = m_heaps[heap].Count;

        return count;
    }

    public List<Bead> GetSelectedBeads()
    {
        List<Bead> selectedBeads = new List<Bead>();

        for (int i = 0; i < m_heaps.Count; ++i)
        {
            for (int j = 0; j < m_heaps[i].Count; ++j)
            {
                if (m_heaps[i][j].Selected)
                {
                    selectedBeads.Add(m_heaps[i][j]);
                }
            }
        }

        return selectedBeads;
    }
}
