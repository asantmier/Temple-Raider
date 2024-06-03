using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Fader : MonoBehaviour
{
    Image image;
    Coroutine fadeRoutine;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    /// <summary>
    /// Applies a black filter over the screen that slowly turns solid and then stays.
    /// </summary>
    /// <param name="length">Time to animate</param>
    public void FadeOut(float length)
    {
        image.enabled = true;
        if (fadeRoutine != null )
        {
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine = StartCoroutine("FadeOutHelper", length);
    }

    /// <summary>
    /// Applies a black filter over the screen that slowly turns transparent and then disappears.
    /// </summary>
    /// <param name="length">Time to animate</param>
    public void FadeIn(float length)
    {
        image.enabled = true;
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine = StartCoroutine("FadeInHelper", length);
    }

    /// <summary>
    /// Fades to black, then back to transparent.
    /// </summary>
    /// <param name="length">Time to animate each fade</param>
    public void FadeOutAndIn(float length)
    {
        image.enabled = true;
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine = StartCoroutine("FadeOutAndInHelper", length);
    }

    IEnumerator FadeOutHelper(float length)
    {
        float time = 0;
        while (time < length)
        {
            var tmp = image.color;
            tmp.a = Mathf.Lerp(0f, 1f, time / length);
            image.color = tmp;
            time = Mathf.Clamp(time + Time.deltaTime, 0, length);
            yield return new WaitForEndOfFrame();
        }
        // let image stay enabled
    }

    IEnumerator FadeInHelper(float length)
    {
        float time = 0;
        while (time < length)
        {
            var tmp = image.color;
            tmp.a = Mathf.Lerp(1f, 0f, time / length);
            image.color = tmp;
            time = Mathf.Clamp(time + Time.deltaTime, 0, length);
            yield return new WaitForEndOfFrame();
        }
        image.enabled = false;
    }

    IEnumerator FadeOutAndInHelper(float length)
    {
        StartCoroutine("FadeOutHelper", length);
        yield return new WaitForSeconds(length);
        StartCoroutine("FadeInHelper", length);
        yield return new WaitForSeconds(length);
        image.enabled = false;
    }
}
