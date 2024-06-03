using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    AudioSource sfx;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();  
    }

    public void Open()
    {
        if (!anim.GetBool("open"))
        {
            anim.SetBool("open", true);
            sfx.Play();
        }
    }

    public void Close()
    {
        if (anim.GetBool("open"))
        {
            anim.SetBool("open", false);
            sfx.Play();
        }
    }

    public void Flip()
    {
        anim.SetBool("open", !anim.GetBool("open"));
        sfx.Play();
    }
}
