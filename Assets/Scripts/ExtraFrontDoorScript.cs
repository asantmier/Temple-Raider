using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraFrontDoorScript : MonoBehaviour
{
    public GameObject sun;
    public Collider invisibleWall;
    public AudioSource jungle;
    public AudioSource dungeon;


    public void TurnOffSun()
    {
        sun.SetActive(false);
    }
    public void TurnOnSun()
    {
        sun.SetActive(true);
    }
    public void ActivateSafetyWall()
    {
        invisibleWall.enabled = true;
    }
    public void DeactivateSafetyWall()
    {
        invisibleWall.enabled = false;
    }
    public void SwapToDungeonMusic()
    {
        jungle.Stop();
        dungeon.Play();
    }
}
