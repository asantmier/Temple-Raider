using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchonizedTrap : MonoBehaviour
{
    public float startOffset = 0.0f;
    public float deploySpikesAt = 0.5f;
    public float retractSpikesAt = 1.0f;

    private Animator anim;
    private bool running = false;
    private float iTimer;

    private AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!running) return;

        iTimer += Time.deltaTime;

        if ((iTimer - startOffset) % (deploySpikesAt + retractSpikesAt) > deploySpikesAt)
        {
            anim.SetBool("deployed", true);
        } else
        {
            anim.SetBool("deployed", false);
        }

    }

    public void SynchonizedUpdateBegin()
    {
        running = true;
        iTimer = 0;
    }

    public void SynchonizedUpdateEnd()
    {
        running = false;
    }

    public void PlaySound()
    {
        if (sfx != null)
        {
            sfx.Play();
        }
    }
}
