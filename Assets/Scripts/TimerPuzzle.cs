using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPuzzle : MonoBehaviour
{
    public Animator[] animators;
    public float time;

    bool running;
    float counter;

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            counter += Time.deltaTime;
            if (counter > time) {
                DeActivate();
            }
        }
    }

    void Activate()
    {
        running = true;
        foreach (var animator in animators)
        {
            animator.SetBool("active", true);
        }
        counter = 0;
    }

    void DeActivate()
    {
        running = false;
        foreach (var animator in animators)
        {
            animator.SetBool("active", false);
        }
    }

    public void BeginTimer()
    {
        Activate();
    }

    public void EndTimer() 
    {
        DeActivate();
    }
}
