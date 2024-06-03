using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePuzzle : MonoBehaviour
{
    public Animator door;
    private AudioSource sfx;

    private void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        door.SetBool("solved", true);
        sfx.Play();
    }
}
