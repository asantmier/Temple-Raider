using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeAdjustment : MonoBehaviour
{
    [Range(0f, 1f)]
    public float percent;
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = percent;
        volumeSlider.value = percent;
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(volumeSlider.value); });
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = percent;
    }

    public void SetVolume(float newVol)
    {
        percent = newVol;
    }
}
