using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public AudioSource jungle;
    public AudioSource dungeon;
    public PauseMenu pauseMenu;

    private void OnTriggerEnter(Collider other)
    {
        dungeon.Stop();
        jungle.Play();
        pauseMenu.DoVictory();
    }
}
