using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : ScriptableObject 
{
	//BoardManager.m_heaps.Count()
	//BoardManager.IsValidHeap()
	//BoardManager.BeadCountInHeaps()

	//Bead.Select()

	public void MakeMove()
	{
		BoardManager board = BoardManager.Instance;
		int heapCount = board.m_heaps.Count;
		bool validMove = false;
		while(!validMove)
		{
			int heapSelect = Random.Range(0, heapCount);
			if(board.IsValidHeap(heapSelect))
			{
				int beadsInHeap = board.BeadCountInHeap(heapSelect);
				int selected = Random.Range(1, beadsInHeap + 1);
				for(int i = 0; i < selected; i++)
				{
					board.m_heaps[heapSelect][i].Select();
				}
				validMove = true;
			}	
		}
		RemoveManager.Instance.RemoveSelectedBeads();
	}	

}
