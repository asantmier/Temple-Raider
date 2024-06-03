using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject flame;
    public GameObject light;

    public void On()
    {
        flame.SetActive(true);
        light.SetActive(true);
    }

    public void Off()
    {
        flame.SetActive(false);
        light.SetActive(false);
    }
}
