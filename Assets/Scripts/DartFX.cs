using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartFX : MonoBehaviour
{
    public Transform children;
    public float minRange;
    public float maxRange;
    public int cap;

    public void Play()
    {
        StartCoroutine("PlayHelper");
    }

    IEnumerator PlayHelper()
    {
        float delay = 0f;
        for (int i = 0; i < children.childCount; i++)
        {
            if (i > cap) { break;  }
            yield return new WaitForSeconds(delay);
            children.GetChild(i).GetComponent<AudioSource>().Play();
            children.GetChild(i).GetComponent<AudioSource>().volume = Random.Range(0f, 1f);
            delay = Random.Range(minRange, maxRange);
        }
    }
}
