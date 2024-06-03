using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    public Transform torchHolder;
    public Door door;

    bool[] puzzle;
    Torch[] torches;

    // Start is called before the first frame update
    void Start()
    {
        puzzle = new bool[3];
        for (int i = 0; i < puzzle.Length; i++)
        {
            puzzle[i] = false;
        }
        torches = new Torch[3];
        for (int i = 0;i < torches.Length;i++)
        {
            torches[i] = torchHolder.GetChild(i).GetComponent<Torch>();
            torches[i].Off();
        }
        door.Close();
    }

    public void Complete(int i)
    {
        puzzle[i] = true;
        torches[i].On();
        TrySolve();
    }

    void TrySolve()
    {
        foreach (bool b in puzzle)
        {
            if (!b) { return; }
        }
        door.Open();
    }


}
