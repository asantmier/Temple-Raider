using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLoader : MonoBehaviour
{
    public static List<GameObject> allAreas = new List<GameObject>();
    public static List<GameObject> requestedAreas = new List<GameObject>();
    public GameObject[] areasToLoad;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject area in areasToLoad)
        {
            if (!allAreas.Contains(area))
            {
                allAreas.Add(area);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject area in areasToLoad)
        {
            requestedAreas.Add(area);
        }
        LoadUnload();
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject area in areasToLoad)
        {
            requestedAreas.Remove(area);
        }
        LoadUnload();
    }

    static void LoadUnload()
    {
        foreach (GameObject area in allAreas)
        {
            area.SetActive(requestedAreas.Contains(area));
        }
    }
}
