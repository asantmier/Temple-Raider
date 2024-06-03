using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TrapSynchonizer : MonoBehaviour
{
    public List<SynchonizedTrap> synchronizedTrapList;
    public bool active;
    private bool lastactive;

    // Start is called before the first frame update
    void Start()
    {
        synchronizedTrapList = new List<SynchonizedTrap>(FindObjectsOfType<SynchonizedTrap>());
        if (active )
        {
            StartTraps();
        }
        lastactive = active;
    }

    // Update is called once per frame
    void Update()
    {
        if (active != lastactive)
        {
            if (active)
            {
                StartTraps();
            } else
            {
                StopTraps();
            }
            lastactive=active;
        }
    }

    public void StartTraps()
    {
        foreach (SynchonizedTrap trap in synchronizedTrapList)
        {
            trap.SynchonizedUpdateBegin();
        }
    }

    public void StopTraps()
    {
        foreach (SynchonizedTrap trap in synchronizedTrapList)
        {
            trap.SynchonizedUpdateEnd();
        }
    }
}
